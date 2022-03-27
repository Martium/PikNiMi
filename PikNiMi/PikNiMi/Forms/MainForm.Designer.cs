
using System;

namespace PikNiMi.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableUpperLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateProductButton = new System.Windows.Forms.Button();
            this.AddNewProductButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.CancelSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ProductTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MoneyCourseInfoLabel = new System.Windows.Forms.Label();
            this.MoneyCourseTextBox = new System.Windows.Forms.TextBox();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.tableBottomLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TripExpensesTextBox = new System.Windows.Forms.TextBox();
            this.AdditionalOptionButton = new System.Windows.Forms.Button();
            this.AddNewProductTypeButton = new System.Windows.Forms.Button();
            this.HistoryButton = new System.Windows.Forms.Button();
            this.CountFullOrderDiscountButton = new System.Windows.Forms.Button();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.tableUpperLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.tableBottomLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableUpperLayoutPanel
            // 
            this.tableUpperLayoutPanel.ColumnCount = 6;
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.91545F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.91546F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.42272F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.91546F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.91546F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.91546F));
            this.tableUpperLayoutPanel.Controls.Add(this.UpdateProductButton, 1, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.AddNewProductButton, 0, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.SearchTextBox, 3, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.CancelSearchButton, 5, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.SearchButton, 4, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.ProductTypeComboBox, 2, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.MoneyCourseInfoLabel, 2, 1);
            this.tableUpperLayoutPanel.Controls.Add(this.MoneyCourseTextBox, 3, 1);
            this.tableUpperLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableUpperLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableUpperLayoutPanel.Name = "tableUpperLayoutPanel";
            this.tableUpperLayoutPanel.RowCount = 2;
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.Size = new System.Drawing.Size(800, 100);
            this.tableUpperLayoutPanel.TabIndex = 0;
            // 
            // UpdateProductButton
            // 
            this.UpdateProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateProductButton.AutoSize = true;
            this.UpdateProductButton.Location = new System.Drawing.Point(130, 3);
            this.UpdateProductButton.Name = "UpdateProductButton";
            this.UpdateProductButton.Size = new System.Drawing.Size(121, 44);
            this.UpdateProductButton.TabIndex = 2;
            this.UpdateProductButton.TabStop = false;
            this.UpdateProductButton.Text = "Atnaujinti produktą";
            this.UpdateProductButton.UseVisualStyleBackColor = true;
            this.UpdateProductButton.Click += new System.EventHandler(this.UpdateProductButton_Click);
            // 
            // AddNewProductButton
            // 
            this.AddNewProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewProductButton.AutoSize = true;
            this.AddNewProductButton.Location = new System.Drawing.Point(3, 3);
            this.AddNewProductButton.Name = "AddNewProductButton";
            this.AddNewProductButton.Size = new System.Drawing.Size(121, 44);
            this.AddNewProductButton.TabIndex = 1;
            this.AddNewProductButton.TabStop = false;
            this.AddNewProductButton.Text = "Pridėti naują produktą";
            this.AddNewProductButton.UseVisualStyleBackColor = true;
            this.AddNewProductButton.Click += new System.EventHandler(this.AddNewProductButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(420, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(121, 20);
            this.SearchTextBox.TabIndex = 3;
            this.SearchTextBox.TabStop = false;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.SearchTextBox.GotFocus += new System.EventHandler(this.SearchTextBox_GotFocus);
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            this.SearchTextBox.LostFocus += new System.EventHandler(this.SearchTextBox_LostFocus);
            // 
            // CancelSearchButton
            // 
            this.CancelSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelSearchButton.AutoSize = true;
            this.CancelSearchButton.Location = new System.Drawing.Point(674, 3);
            this.CancelSearchButton.Name = "CancelSearchButton";
            this.CancelSearchButton.Size = new System.Drawing.Size(123, 44);
            this.CancelSearchButton.TabIndex = 5;
            this.CancelSearchButton.TabStop = false;
            this.CancelSearchButton.Text = "atšaukti";
            this.CancelSearchButton.UseVisualStyleBackColor = true;
            this.CancelSearchButton.Click += new System.EventHandler(this.CancelSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.AutoSize = true;
            this.SearchButton.Location = new System.Drawing.Point(547, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(121, 44);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.TabStop = false;
            this.SearchButton.Text = "ieškoti";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ProductTypeComboBox
            // 
            this.ProductTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductTypeComboBox.FormattingEnabled = true;
            this.ProductTypeComboBox.Location = new System.Drawing.Point(257, 3);
            this.ProductTypeComboBox.Name = "ProductTypeComboBox";
            this.ProductTypeComboBox.Size = new System.Drawing.Size(157, 21);
            this.ProductTypeComboBox.TabIndex = 0;
            this.ProductTypeComboBox.TabStop = false;
            this.ProductTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductTypeComboBox_SelectedIndexChanged);
            // 
            // MoneyCourseInfoLabel
            // 
            this.MoneyCourseInfoLabel.AutoSize = true;
            this.MoneyCourseInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoneyCourseInfoLabel.Location = new System.Drawing.Point(257, 50);
            this.MoneyCourseInfoLabel.Name = "MoneyCourseInfoLabel";
            this.MoneyCourseInfoLabel.Size = new System.Drawing.Size(157, 50);
            this.MoneyCourseInfoLabel.TabIndex = 6;
            this.MoneyCourseInfoLabel.Text = "Money Course";
            // 
            // MoneyCourseTextBox
            // 
            this.MoneyCourseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoneyCourseTextBox.Location = new System.Drawing.Point(420, 53);
            this.MoneyCourseTextBox.Name = "MoneyCourseTextBox";
            this.MoneyCourseTextBox.Size = new System.Drawing.Size(121, 20);
            this.MoneyCourseTextBox.TabIndex = 7;
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            this.ProductDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(3, 106);
            this.ProductDataGridView.MultiSelect = false;
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.ReadOnly = true;
            this.ProductDataGridView.Size = new System.Drawing.Size(794, 264);
            this.ProductDataGridView.TabIndex = 1;
            this.ProductDataGridView.TabStop = false;
            // 
            // tableBottomLayoutPanel
            // 
            this.tableBottomLayoutPanel.ColumnCount = 6;
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableBottomLayoutPanel.Controls.Add(this.TripExpensesTextBox, 4, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.AdditionalOptionButton, 2, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.AddNewProductTypeButton, 1, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.HistoryButton, 0, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.CountFullOrderDiscountButton, 5, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.DateTextBox, 3, 0);
            this.tableBottomLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableBottomLayoutPanel.Location = new System.Drawing.Point(0, 376);
            this.tableBottomLayoutPanel.Name = "tableBottomLayoutPanel";
            this.tableBottomLayoutPanel.RowCount = 1;
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.Size = new System.Drawing.Size(800, 74);
            this.tableBottomLayoutPanel.TabIndex = 2;
            // 
            // TripExpensesTextBox
            // 
            this.TripExpensesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TripExpensesTextBox.Location = new System.Drawing.Point(535, 3);
            this.TripExpensesTextBox.Name = "TripExpensesTextBox";
            this.TripExpensesTextBox.Size = new System.Drawing.Size(127, 20);
            this.TripExpensesTextBox.TabIndex = 10;
            this.TripExpensesTextBox.TabStop = false;
            this.TripExpensesTextBox.GotFocus += new System.EventHandler(this.TripExpensesTextBox_GotFocus);
            this.TripExpensesTextBox.LostFocus += new System.EventHandler(this.TripExpensesTextBox_LostFocus);
            // 
            // AdditionalOptionButton
            // 
            this.AdditionalOptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdditionalOptionButton.Location = new System.Drawing.Point(269, 3);
            this.AdditionalOptionButton.Name = "AdditionalOptionButton";
            this.AdditionalOptionButton.Size = new System.Drawing.Size(127, 68);
            this.AdditionalOptionButton.TabIndex = 8;
            this.AdditionalOptionButton.TabStop = false;
            this.AdditionalOptionButton.Text = "Nuolaidos";
            this.AdditionalOptionButton.UseVisualStyleBackColor = true;
            this.AdditionalOptionButton.Click += new System.EventHandler(this.AdditionalOptionButton_Click);
            // 
            // AddNewProductTypeButton
            // 
            this.AddNewProductTypeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewProductTypeButton.AutoSize = true;
            this.AddNewProductTypeButton.Location = new System.Drawing.Point(136, 3);
            this.AddNewProductTypeButton.Name = "AddNewProductTypeButton";
            this.AddNewProductTypeButton.Size = new System.Drawing.Size(127, 68);
            this.AddNewProductTypeButton.TabIndex = 7;
            this.AddNewProductTypeButton.TabStop = false;
            this.AddNewProductTypeButton.Text = "Naujas produkto\r\ntipas";
            this.AddNewProductTypeButton.UseVisualStyleBackColor = true;
            this.AddNewProductTypeButton.Click += new System.EventHandler(this.AddNewProductTypeButton_Click);
            // 
            // HistoryButton
            // 
            this.HistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryButton.AutoSize = true;
            this.HistoryButton.Location = new System.Drawing.Point(3, 3);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(127, 68);
            this.HistoryButton.TabIndex = 6;
            this.HistoryButton.TabStop = false;
            this.HistoryButton.Text = "Istorija";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // CountFullOrderDiscountButton
            // 
            this.CountFullOrderDiscountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CountFullOrderDiscountButton.AutoSize = true;
            this.CountFullOrderDiscountButton.Location = new System.Drawing.Point(668, 3);
            this.CountFullOrderDiscountButton.Name = "CountFullOrderDiscountButton";
            this.CountFullOrderDiscountButton.Size = new System.Drawing.Size(129, 68);
            this.CountFullOrderDiscountButton.TabIndex = 9;
            this.CountFullOrderDiscountButton.TabStop = false;
            this.CountFullOrderDiscountButton.Text = "Skaičiuoti savikainą";
            this.CountFullOrderDiscountButton.UseVisualStyleBackColor = true;
            this.CountFullOrderDiscountButton.Click += new System.EventHandler(this.CountFullOrderDiscountButton_Click);
            // 
            // DateTextBox
            // 
            this.DateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTextBox.Location = new System.Drawing.Point(402, 3);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(127, 20);
            this.DateTextBox.TabIndex = 6;
            this.DateTextBox.TabStop = false;
            this.DateTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.DateTextBox_Validating);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableBottomLayoutPanel);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.tableUpperLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tableUpperLayoutPanel.ResumeLayout(false);
            this.tableUpperLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.tableBottomLayoutPanel.ResumeLayout(false);
            this.tableBottomLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableUpperLayoutPanel;
        private System.Windows.Forms.ComboBox ProductTypeComboBox;
        private System.Windows.Forms.Button AddNewProductButton;
        private System.Windows.Forms.Button UpdateProductButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button CancelSearchButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableBottomLayoutPanel;
        private System.Windows.Forms.Button CountFullOrderDiscountButton;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.TextBox TripExpensesTextBox;
        private System.Windows.Forms.Label MoneyCourseInfoLabel;
        private System.Windows.Forms.TextBox MoneyCourseTextBox;
        private System.Windows.Forms.Button HistoryButton;
        private System.Windows.Forms.Button AddNewProductTypeButton;
        private System.Windows.Forms.Button AdditionalOptionButton;
    }
}

