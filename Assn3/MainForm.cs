﻿using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace Forests
{
    // NOTE: There some design problems with this class

    public partial class MainForm : Form
    {
        private readonly Drawing _drawing;
        private bool _forceRedraw;
        private readonly Invoker _invoker;
        private string _currentEmoteResource;
        private float _currentScale = 1;
        private bool _showRubberBand;
        private bool _eraseLastRubberBand;
        private Point _startingPoint;
        private Point _lastRubberBandEnd;
        private Point _rubberBandStart;
        private Point _rubberBandEnd;


        private enum PossibleModes
        {
            None,
            EmoteDrawing,
            LineDrawing,
            BoxDrawing,
            Selection,
            Move
        };

        private PossibleModes _mode = PossibleModes.None;

        private Bitmap _imageBuffer;
        private Graphics _imageBufferGraphics;
        private Graphics _panelGraphics;
       
        public MainForm()
        {
            InitializeComponent();

            EmoteFactory.Instance.ResourceNamePattern = @"Forests.Graphics.{0}.png";
            EmoteFactory.Instance.ReferenceType = typeof(Program);

            _drawing = new Drawing();
            _invoker = new Invoker();
            CommandFactory.Instance.TargetDrawing = _drawing;
            CommandFactory.Instance.Invoker = _invoker;

            _invoker.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayDrawing();
        }

        private void DisplayDrawing()
        {
            if (_imageBuffer == null)
            {
                _imageBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                _imageBufferGraphics = Graphics.FromImage(_imageBuffer);
                _panelGraphics = drawingPanel.CreateGraphics();
            }

            if (_drawing.Draw(_imageBufferGraphics, _forceRedraw))
                _panelGraphics.DrawImageUnscaled(_imageBuffer, 0, 0);

            _forceRedraw = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.CreateAndDo("new");
        }

        private void ClearOtherSelectedTools(ToolStripButton ignoreItem)
        {
            foreach (var item in drawingToolStrip.Items)
            {
                var toolButton = item as ToolStripButton;
                if (toolButton != null && item!=ignoreItem && toolButton.Checked )
                    toolButton.Checked = false;
            }
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button!=null && button.Checked)
            {
                _mode = PossibleModes.Selection;
                _currentEmoteResource = string.Empty;
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }
        }

        private void emoteButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
                _currentEmoteResource = button.Text;
            else
                _currentEmoteResource = string.Empty;

            CommandFactory.Instance.CreateAndDo("deselect");
            _mode = (_currentEmoteResource != string.Empty) ? PossibleModes.EmoteDrawing : PossibleModes.None;
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_mode)
            {
                case PossibleModes.BoxDrawing:
                    {
                        var form = new LabelBoxForm
                        {
                            DesktopLocation = 
                                new Point(ClientRectangle.Left + e.Location.X,
                                    ClientRectangle.Top + e.Location.Y)
                        };

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var minX = Math.Min(_startingPoint.X, e.Location.X);
                            var maxX = Math.Max(_startingPoint.X, e.Location.X);
                            var minY = Math.Min(_startingPoint.Y, e.Location.Y);
                            var maxY = Math.Max(_startingPoint.Y, e.Location.Y);

                            var size = new Size() {Width = maxX - minX, Height = maxY - minY};
                            CommandFactory.Instance.CreateAndDo("addbox", form.LabelText, _startingPoint, size);
                        }
                        break;
                    }
                case PossibleModes.LineDrawing:
                    CommandFactory.Instance.CreateAndDo("addline", _startingPoint, e.Location);
                    break;
                case PossibleModes.EmoteDrawing:
                    if (!string.IsNullOrWhiteSpace(_currentEmoteResource))
                        CommandFactory.Instance.CreateAndDo("addemote", _currentEmoteResource, e.Location, _currentScale);
                    break;
                case PossibleModes.Selection:
                    CommandFactory.Instance.CreateAndDo("select", e.Location);
                    break;
                case PossibleModes.Move:
                    CommandFactory.Instance.CreateAndDo("moveselected", e.Location);
                    break;
            }

            _showRubberBand = false;
            _eraseLastRubberBand = false;
        }

        private void scale_Leave(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
            scale.Text = _currentScale.ToString(CultureInfo.InvariantCulture);
        }

        private float ConvertToFloat(string text, float min, float max, float defaultValue)
        {
            var result = defaultValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                result = !float.TryParse(text, out result) ? defaultValue : Math.Max(min, Math.Min(max, result));
            }
            return result;
        }

        private void scale_TextChanged(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "json",
                Multiselect = false,
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("load", dialog.FileName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "json",
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("save", dialog.FileName);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
        }

        private void ComputeDrawingPanelSize()
        {
            var width = Width - drawingToolStrip.Width;
            var height = Height - fileToolStrip.Height;

            drawingPanel.Size = new Size(width, height);
            drawingPanel.Location = new Point(drawingToolStrip.Width, fileToolStrip.Height);

            _imageBuffer = null;

            _forceRedraw = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.CreateAndDo("remove");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _invoker?.Stop();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            _invoker.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            _invoker.Redo();
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            _mode = PossibleModes.LineDrawing;
        }

        private void labelBoxButton_Click(object sender, EventArgs e)
        {
            _mode = PossibleModes.BoxDrawing;
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_mode != PossibleModes.BoxDrawing && _mode != PossibleModes.LineDrawing) return;

            _startingPoint = e.Location;
            _rubberBandStart = ComputeAbsolutePoint(e.Location);          
            _showRubberBand = true;
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_showRubberBand) return;

            _rubberBandEnd = ComputeAbsolutePoint(e.Location);

            switch (_mode)
            {
                case PossibleModes.LineDrawing:
                    DrawRubberBandLine();
                    break;
                case PossibleModes.BoxDrawing:
                    DrawRubberBandBox();
                    break;
            }

            _eraseLastRubberBand = true;
            _lastRubberBandEnd = _rubberBandEnd;
        }

        private void DrawRubberBandLine()
        {

            if (_eraseLastRubberBand)
                EraseOldRubberBandLine();

            ControlPaint.DrawReversibleLine(_rubberBandStart, _rubberBandEnd, Color.Gray);
        }

        private void EraseOldRubberBandLine()
        {
            ControlPaint.DrawReversibleLine(_rubberBandStart, _lastRubberBandEnd, Color.Gray);
        }

        private void DrawRubberBandBox()
        {
            if (_eraseLastRubberBand)
                EraseOldRubberBandFrame();

            var rectangle = new Rectangle(_rubberBandStart.X, _rubberBandStart.Y,
                                        _rubberBandEnd.X - _rubberBandStart.X, _rubberBandEnd.Y - _rubberBandStart.Y);
            ControlPaint.DrawReversibleFrame(rectangle, Color.Gray, FrameStyle.Dashed);
        }

        private void EraseOldRubberBandFrame()
        {
            var oldRectangle = new Rectangle(_rubberBandStart.X, _rubberBandStart.Y,
                                        _lastRubberBandEnd.X - _rubberBandStart.X, _lastRubberBandEnd.Y - _rubberBandStart.Y);
            ControlPaint.DrawReversibleFrame(oldRectangle, Color.Gray, FrameStyle.Dashed);
        }

        private Point ComputeAbsolutePoint(Point location)
        {
            var p1 = this.PointToScreen(new Point(0, 0));
            var p2 = drawingPanel.PointToScreen(new Point(0, 0));

            var p4 = drawingPanel.PointToScreen(
                        new Point(drawingPanel.ClientRectangle.Left + location.X,
                        drawingPanel.ClientRectangle.Top + location.Y));
            return p4;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("updatebackground", colorDialog.Color.ToArgb().ToString());             
            }
        }

        private void moveToolStripButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);
            
            if (button != null && button.Checked)
            {
                _mode = PossibleModes.Move;
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }
        }
        
        private void resizeStripButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                CommandFactory.Instance.CreateAndDo("resize", float.Parse(scale.Text));
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }            
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                // Delete
                case 'D':
                case 'd':
                    deleteButton.PerformClick();
                    break;

                case 'C':
                case 'c':
                    copyButton.PerformClick();
                    break;

                case 'U':
                case 'u':
                    undoButton.PerformClick();
                    break;

                case 'R':
                case 'r':
                    redoButton.PerformClick();
                    break;
                
                case 'P':
                case 'p':
                    pointerButton.PerformClick();
                    break;

                case 'M':
                case 'm':
                    moveToolStripButton.PerformClick();
                    break;

                case 'A':
                case 'a':
                    resizeStripButton.PerformClick();
                    break;                

                case 'S':
                case 's':
                    saveButton.PerformClick();
                    break;

                case 'E':
                case 'e':
                    exportButton.PerformClick();
                    break;

                case 'O':
                case 'o':
                    openButton.PerformClick();
                    break;

                case 'N':
                case 'n':
                    newButton.PerformClick();
                    break;

                case 'B':
                case 'b':
                    backgroundButton.PerformClick();
                    break;

                case '1':
                    emote01Button.PerformClick();
                    break;

                case '2':
                    emote02Button.PerformClick();
                    break;

                case '3':
                    emote03Button.PerformClick();
                    break;

                case '4':
                    emote04Button.PerformClick();
                    break;
                    
                case '5':
                    emote05Button.PerformClick();
                    break;

                case '6':
                    emote06Button.PerformClick();
                    break;

                case '7':
                    emote07Button.PerformClick();
                    break;                   
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);

            var dialog = new SaveFileDialog
            {
                DefaultExt = "png",
                RestoreDirectory = true,
                Filter = @"png files (*.png)|*.png|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndDo("export", dialog.FileName, bitmap);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                CommandFactory.Instance.CreateAndDo("copy");
            }
            else
            {
                CommandFactory.Instance.CreateAndDo("deselect");
                _mode = PossibleModes.None;
            }
        }
    }
}
