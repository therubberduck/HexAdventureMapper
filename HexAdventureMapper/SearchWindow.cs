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

        private bool _allowSelection = false;

        public HexCoordinate ReturnValue { get; private set; }

        public SearchWindow(DbHex dbHexes, string searchText)
        {
            InitializeComponent();

            _dbHexes = dbHexes;
            txtSearchTerm.Text = searchText;
            if (searchText != "") DoSearch(searchText);
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
            var results = _dbHexes.GetHexesWithDetail(searchTerm);
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
    }
}