using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.UI.Controls
{
    public partial class LogListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.threadColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));

            this.logImageList = new System.Windows.Forms.ImageList(this.components);


            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateColumn,
            this.threadColumn,
            this.typeColumn,
            this.classColumn,
            this.messageColumn});

            this.FullRowSelect = true;
            this.HideSelection = false;
            this.OwnerDraw = true;
            this.VirtualMode = true;
            

            // 
            // dateColumn
            // 
            this.dateColumn.Text = "Date";
            this.dateColumn.Width = 150;
            // 
            // threadColumn
            // 
            this.threadColumn.Text = "Thread";
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            // 
            // classColumn
            // 
            this.classColumn.Text = "Class";
            this.classColumn.Width = 80;
            // 
            // messageColumn
            // 
            this.messageColumn.Text = "Message";
            this.messageColumn.Width = 450;

            // 
            // logImageList
            // 
            this.logImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.logImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.logImageList.TransparentColor = System.Drawing.Color.Magenta;
        }

        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.ColumnHeader threadColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.ColumnHeader classColumn;
        private System.Windows.Forms.ColumnHeader messageColumn;
        private System.Windows.Forms.ImageList logImageList;

    }
}
