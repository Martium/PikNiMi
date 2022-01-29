
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
            this.updateProductButton = new System.Windows.Forms.Button();
            this.addNewProductButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.cancelSearchButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.productTypeComboBox = new System.Windows.Forms.ComboBox();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.tableBottomLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tripExpensesTextBox = new System.Windows.Forms.TextBox();
            this.discountButton = new System.Windows.Forms.Button();
            this.AddNewProductTypeButton = new System.Windows.Forms.Button();
            this.Historybutton = new System.Windows.Forms.Button();
            this.countFullOrderDiscountButton = new System.Windows.Forms.Button();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.tableUpperLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            this.tableBottomLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableUpperLayoutPanel
            // 
            this.tableUpperLayoutPanel.ColumnCount = 6;
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableUpperLayoutPanel.Controls.Add(this.updateProductButton, 1, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.addNewProductButton, 0, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.searchTextBox, 3, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.cancelSearchButton, 5, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.searchButton, 4, 0);
            this.tableUpperLayoutPanel.Controls.Add(this.productTypeComboBox, 2, 0);
            this.tableUpperLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableUpperLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableUpperLayoutPanel.Name = "tableUpperLayoutPanel";
            this.tableUpperLayoutPanel.RowCount = 2;
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableUpperLayoutPanel.Size = new System.Drawing.Size(800, 100);
            this.tableUpperLayoutPanel.TabIndex = 0;
            // 
            // updateProductButton
            // 
            this.updateProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateProductButton.Location = new System.Drawing.Point(99, 3);
            this.updateProductButton.Name = "updateProductButton";
            this.updateProductButton.Size = new System.Drawing.Size(90, 44);
            this.updateProductButton.TabIndex = 2;
            this.updateProductButton.TabStop = false;
            this.updateProductButton.Text = "Atnaujinti produktą";
            this.updateProductButton.UseVisualStyleBackColor = true;
            // 
            // addNewProductButton
            // 
            this.addNewProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewProductButton.Location = new System.Drawing.Point(3, 3);
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Size = new System.Drawing.Size(90, 44);
            this.addNewProductButton.TabIndex = 1;
            this.addNewProductButton.TabStop = false;
            this.addNewProductButton.Text = "Pridėti naują produktą";
            this.addNewProductButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(515, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(90, 20);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TabStop = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.GotFocus += new System.EventHandler(this.searchTextBox_GotFocus);
            this.searchTextBox.LostFocus += new System.EventHandler(this.searchTextBox_LostFocus);
            // 
            // cancelSearchButton
            // 
            this.cancelSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelSearchButton.Location = new System.Drawing.Point(707, 3);
            this.cancelSearchButton.Name = "cancelSearchButton";
            this.cancelSearchButton.Size = new System.Drawing.Size(90, 44);
            this.cancelSearchButton.TabIndex = 5;
            this.cancelSearchButton.TabStop = false;
            this.cancelSearchButton.Text = "atšaukti";
            this.cancelSearchButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(611, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(90, 44);
            this.searchButton.TabIndex = 4;
            this.searchButton.TabStop = false;
            this.searchButton.Text = "ieškoti";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // productTypeComboBox
            // 
            this.productTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productTypeComboBox.FormattingEnabled = true;
            this.productTypeComboBox.Location = new System.Drawing.Point(195, 3);
            this.productTypeComboBox.Name = "productTypeComboBox";
            this.productTypeComboBox.Size = new System.Drawing.Size(314, 21);
            this.productTypeComboBox.TabIndex = 0;
            this.productTypeComboBox.TabStop = false;
            // 
            // productDataGridView
            // 
            this.productDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Location = new System.Drawing.Point(3, 106);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.Size = new System.Drawing.Size(794, 264);
            this.productDataGridView.TabIndex = 1;
            this.productDataGridView.TabStop = false;
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
            this.tableBottomLayoutPanel.Controls.Add(this.tripExpensesTextBox, 4, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.discountButton, 2, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.AddNewProductTypeButton, 1, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.Historybutton, 0, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.countFullOrderDiscountButton, 5, 0);
            this.tableBottomLayoutPanel.Controls.Add(this.dateTextBox, 3, 0);
            this.tableBottomLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableBottomLayoutPanel.Location = new System.Drawing.Point(0, 376);
            this.tableBottomLayoutPanel.Name = "tableBottomLayoutPanel";
            this.tableBottomLayoutPanel.RowCount = 2;
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBottomLayoutPanel.Size = new System.Drawing.Size(800, 74);
            this.tableBottomLayoutPanel.TabIndex = 2;
            // 
            // tripExpensesTextBox
            // 
            this.tripExpensesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tripExpensesTextBox.Location = new System.Drawing.Point(535, 3);
            this.tripExpensesTextBox.Name = "tripExpensesTextBox";
            this.tripExpensesTextBox.Size = new System.Drawing.Size(127, 20);
            this.tripExpensesTextBox.TabIndex = 10;
            this.tripExpensesTextBox.TabStop = false;
            this.tripExpensesTextBox.GotFocus += new System.EventHandler(this.tripExpensesTextBox_GotFocus);
            this.tripExpensesTextBox.LostFocus += new System.EventHandler(this.tripExpensesTextBox_LostFocus);
            // 
            // discountButton
            // 
            this.discountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discountButton.Location = new System.Drawing.Point(269, 3);
            this.discountButton.Name = "discountButton";
            this.discountButton.Size = new System.Drawing.Size(127, 31);
            this.discountButton.TabIndex = 8;
            this.discountButton.TabStop = false;
            this.discountButton.Text = "Nuolaidos";
            this.discountButton.UseVisualStyleBackColor = true;
            // 
            // AddNewProductTypeButton
            // 
            this.AddNewProductTypeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewProductTypeButton.Location = new System.Drawing.Point(136, 3);
            this.AddNewProductTypeButton.Name = "AddNewProductTypeButton";
            this.AddNewProductTypeButton.Size = new System.Drawing.Size(127, 31);
            this.AddNewProductTypeButton.TabIndex = 7;
            this.AddNewProductTypeButton.TabStop = false;
            this.AddNewProductTypeButton.Text = "Naujas produkto tipas";
            this.AddNewProductTypeButton.UseVisualStyleBackColor = true;
            // 
            // Historybutton
            // 
            this.Historybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Historybutton.Location = new System.Drawing.Point(3, 3);
            this.Historybutton.Name = "Historybutton";
            this.Historybutton.Size = new System.Drawing.Size(127, 31);
            this.Historybutton.TabIndex = 6;
            this.Historybutton.TabStop = false;
            this.Historybutton.Text = "Istorija";
            this.Historybutton.UseVisualStyleBackColor = true;
            // 
            // countFullOrderDiscountButton
            // 
            this.countFullOrderDiscountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countFullOrderDiscountButton.Location = new System.Drawing.Point(668, 3);
            this.countFullOrderDiscountButton.Name = "countFullOrderDiscountButton";
            this.countFullOrderDiscountButton.Size = new System.Drawing.Size(129, 31);
            this.countFullOrderDiscountButton.TabIndex = 9;
            this.countFullOrderDiscountButton.TabStop = false;
            this.countFullOrderDiscountButton.Text = "Skaičiuoti savikainą";
            this.countFullOrderDiscountButton.UseVisualStyleBackColor = true;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTextBox.Location = new System.Drawing.Point(402, 3);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(127, 20);
            this.dateTextBox.TabIndex = 6;
            this.dateTextBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableBottomLayoutPanel);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.tableUpperLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableUpperLayoutPanel.ResumeLayout(false);
            this.tableUpperLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            this.tableBottomLayoutPanel.ResumeLayout(false);
            this.tableBottomLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableUpperLayoutPanel;
        private System.Windows.Forms.ComboBox productTypeComboBox;
        private System.Windows.Forms.Button addNewProductButton;
        private System.Windows.Forms.Button updateProductButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button cancelSearchButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableBottomLayoutPanel;
        private System.Windows.Forms.Button countFullOrderDiscountButton;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Button discountButton;
        private System.Windows.Forms.Button AddNewProductTypeButton;
        private System.Windows.Forms.Button Historybutton;
        private System.Windows.Forms.TextBox tripExpensesTextBox;
    }
}

