using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HexAdventureMapper.Database.Modules;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper
{
    public partial class SearchWindow : Form
    {
        private DbHex _dbHexes;
        private List<Hex> _results;

        private bool _allowSelection;
        private HexCoordinate _selectedCoordinate;

        public HexCoordinate ReturnValue { get; private set; }

        public SearchWindow(DbHex dbHexes, string searchText, HexCoordinate selectedCoordinate)
        {
            InitializeComponent();

            _dbHexes = dbHexes;
            txtSearchTerm.Text = searchText;
            if (searchText != "") DoSearch(searchText);

            _selectedCoordinate = selectedCoordinate;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearchTerm.Text;
            DoSearch(searchTerm);
        }

        private void txtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) btnSearch_Click(txtSearchTerm, e);
        }

        private void DoSearch(string searchTerm)
        {
            uint.TryParse(txtRange.Text, out var range);

            List<Hex> results;
            if (range == 0)
            {
                results = _dbHexes.GetHexesWithDetail(searchTerm);
            }
            else
            {
                var hexArea = _selectedCoordinate.HexArea(range);
                results = _dbHexes.GetHexesWithDetail(searchTerm, hexArea);
            }
            var orderedResults = results.OrderBy(hex => hex.Coordinate).ToList();
            _results = orderedResults;

            if (_results.Count == 0)
            {
                _allowSelection = false;
                lstResults.Items.Clear();
                rtxtDetail.Text = "";
                var listItem = new ListViewItem {Text = "No Results"};
                lstResults.Items.Add(listItem);
            }
            else
            {
                _allowSelection = true;
                lstResults.Items.Clear();
                rtxtDetail.Text = "";
                var listItems = _results.Select(hex => new ListViewItem
                    {Text = hex.Coordinate.ToText() + ": " + hex.Detail});
                lstResults.Items.AddRange(listItems.ToArray());
            }
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndices.Count > 0 && _allowSelection)
            {
                var selectedIndex = lstResults.SelectedIndices[0];
                var selectedHex = _results[selectedIndex];
                rtxtDetail.Text = selectedHex.Detail;
            }
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndices.Count > 0 && _allowSelection)
            {
                var selectedIndex = lstResults.SelectedIndices[0];
                var selectedHex = _results[selectedIndex];
                ReturnValue = selectedHex.Coordinate;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private const string RangeLabel = "Range";

        private void txtRange_Enter(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            if (box.Text == RangeLabel)
            {
                box.Text = "";
                Font textFont = box.Font;
                box.Font = new Font(textFont.FontFamily, textFont.Size, FontStyle.Regular);
                box.ForeColor = Color.Black;
            }
        }

        private void txtRange_Leave(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            if (box.Text == "")
            {
                box.Text = RangeLabel;
                Font textFont = box.Font;
                box.Font = new Font(textFont.FontFamily, textFont.Size, FontStyle.Bold);
                box.ForeColor = Color.Silver;
            }
        }
    }
}