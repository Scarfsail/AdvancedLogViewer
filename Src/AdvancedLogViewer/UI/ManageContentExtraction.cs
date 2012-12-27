using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL;
using AdvancedLogViewer.BL.ColorHighlight;
using Scarfsail.Common.UI;
using Scarfsail.Common.UI.Controls;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.BL.MessageContentExtraction;

namespace AdvancedLogViewer.UI
{
    public partial class ManageContentExtraction : Form
    {
        internal ManageContentExtraction(MessageContentExtractorConfig config)
        {
            InitializeComponent();
            this.config = config;

            //Load values
            this.PopulateActionsCombo(this.defaultActionCombo, false);
            this.PopulateActionsCombo(this.extractorDefaultActionCombo, true);

            this.defaultActionCombo.SelectedValue = this.config.DefaultAction;
            this.fileExtension.Text = this.config.FileExtension;

            //Bind them into ListBoxe
            this.customExtractorsListBox.DataSource = this.config.CustomExtractors;
            if (this.customExtractorsListBox.Items.Count == 0)
                this.customExtractorsListBox_SelectedIndexChanged(this.customExtractorsListBox, null);

        }


        private void PopulateActionsCombo(ComboBox combo, bool includeDefault)
        {
            Dictionary<string, MessageContentExtractorAction> dict = new Dictionary<string, MessageContentExtractorAction>();
            if (includeDefault)
                dict.Add("General default", MessageContentExtractorAction.Default);
            dict.Add("Open in external application", MessageContentExtractorAction.Open);
            dict.Add("Copy to clipboard", MessageContentExtractorAction.Copy);
            dict.Add("Save to file", MessageContentExtractorAction.Save);

            combo.DataSource = new BindingSource(dict, null);
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";           
        }

        private void AddNewCustomExtractor(CustomMessageExtractor extractor)
        {
            this.config.CustomExtractors.Add(extractor);
            this.RefreshCustomExtractors();
            this.customExtractorsListBox.SelectedItem = extractor;
            this.extractorNameEdit.Focus();
        }

        private void RefreshCustomExtractors()
        {
            object prevSelected = customExtractorsListBox.SelectedItem;

            ((CurrencyManager)customExtractorsListBox.BindingContext[customExtractorsListBox.DataSource]).Refresh();

            if (prevSelected != customExtractorsListBox.SelectedItem)
            {
                this.customExtractorsListBox_SelectedIndexChanged(this.customExtractorsListBox, null);
            }
        }



        private void addNewButton_Click(object sender, EventArgs e)
        {
            this.AddNewCustomExtractor(CustomMessageExtractor.CreateDefaultInstance());
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            CustomMessageExtractor extractor = this.GetSelectedItem();
            if (extractor == null)
                return;

            int index = this.config.CustomExtractors.IndexOf(extractor);
            if (index == 0)
                return;
            this.config.CustomExtractors.RemoveAt(index);

            this.config.CustomExtractors.Insert(index - 1, extractor);

            this.RefreshCustomExtractors();
            this.customExtractorsListBox.SelectedItem = extractor;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            CustomMessageExtractor extractor = this.GetSelectedItem();
            if (extractor == null)
                return;

            int index = this.config.CustomExtractors.IndexOf(extractor);
            if (index == this.config.CustomExtractors.Count - 1)
                return;
            this.config.CustomExtractors.RemoveAt(index);

            this.config.CustomExtractors.Insert(index + 1, extractor);

            this.RefreshCustomExtractors();
            this.customExtractorsListBox.SelectedItem = extractor;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            CustomMessageExtractor extractor = this.GetSelectedItem();
            if (extractor == null)
                return;

            if (MessageBox.Show(String.Format("Do you want to remove custom extractor: '{0}'?", extractor), "Remove custom extractor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.config.CustomExtractors.Remove(extractor);
                this.RefreshCustomExtractors();
            }
        }



        private CustomMessageExtractor GetSelectedItem()
        {
            if (this.customExtractorsListBox.SelectedIndex > -1)
                return this.customExtractorsListBox.SelectedItem as CustomMessageExtractor;

            return null;
        }


        private MessageContentExtractorConfig config;

        private void okButton_Click(object sender, EventArgs e)
        {
            this.config.DefaultAction = (MessageContentExtractorAction)this.defaultActionCombo.SelectedValue;
            this.config.FileExtension = this.fileExtension.Text.Trim('.');

            this.config.Save();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.config.ReloadFromFile();
        }


        private void customExtractorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.removeButton.Enabled = this.customExtractorsListBox.SelectedIndex > -1;
            this.moveUpButton.Enabled = this.customExtractorsListBox.SelectedIndex > 0;
            this.moveDownButton.Enabled = (this.customExtractorsListBox.SelectedIndex > -1) && (this.customExtractorsListBox.SelectedIndex < this.customExtractorsListBox.Items.Count - 1);

            this.LoadSelectedItem();
        }

        private void LoadSelectedItem()
        {
            CustomMessageExtractor item = this.GetSelectedItem();
            if (item != null)
            {
                this.extractorNameEdit.Text = item.ExtractorName;
                this.extractorRegexEdit.Text = item.RegexToExtract;
                this.extractorDefaultActionCombo.SelectedValue = item.DefaultAction;
                this.extractorFileExtensionEdit.Text = item.FileExtension;

                this.editSelectedExtractorPanel.Enabled = true;

            }
            else
            {
                this.extractorNameEdit.Text = "";
                this.extractorRegexEdit.Text = "";
                this.extractorDefaultActionCombo.SelectedValue = MessageContentExtractorAction.Default;
                this.extractorFileExtensionEdit.Text = "";

                this.editSelectedExtractorPanel.Enabled = false;
            }
        }

        private void extractorNameEdit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //Try to save it into LogPattern item
                this.GetSelectedItem().ExtractorName = this.extractorNameEdit.Text;
                this.RefreshCustomExtractors();
                extractorNameError.SetError(extractorNameEdit, "");

            }
            catch (Exception ex)
            {
                extractorNameError.SetError(extractorNameEdit, ex.Message);
                e.Cancel = true;
            }
        }

        private void extractorRegexEdit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //Try to save it into LogPattern item
                this.GetSelectedItem().RegexToExtract = this.extractorRegexEdit.Text;
                extractorRegexError.SetError(extractorRegexEdit, "");

            }
            catch (Exception ex)
            {
                extractorRegexError.SetError(extractorRegexEdit, ex.Message);
                e.Cancel = true;
            }
        }


        private void extractorFileExtensionEdit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //Try to save it into LogPattern item
                this.GetSelectedItem().FileExtension = this.extractorFileExtensionEdit.Text.Trim('.');
                extractorFileExtensionError.SetError(extractorFileExtensionEdit, "");

            }
            catch (Exception ex)
            {
                extractorFileExtensionError.SetError(extractorFileExtensionEdit, ex.Message);
                e.Cancel = true;
            }
        }

        private void extractorDefaultActionCombo_Validating(object sender, CancelEventArgs e)
        {
            this.GetSelectedItem().DefaultAction = (MessageContentExtractorAction)this.extractorDefaultActionCombo.SelectedValue;
        }



        private void createCopyButton_Click(object sender, EventArgs e)
        {
            this.AddNewCustomExtractor(new CustomMessageExtractor(this.GetSelectedItem()));
        }



    }
}



