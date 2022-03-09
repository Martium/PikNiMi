
namespace PikNiMi.Forms
{
    partial class ProductTypeForm
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
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddNewProductTypeButton = new System.Windows.Forms.Button();
            this.ProductTypeTextBox = new System.Windows.Forms.TextBox();
            this.DeleteProductTypeButton = new System.Windows.Forms.Button();
            this.DeleteProductTypeTextBox = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 4;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Controls.Add(this.AddNewProductTypeButton, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.ProductTypeTextBox, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.DeleteProductTypeButton, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.DeleteProductTypeTextBox, 1, 1);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 4;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.11111F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.88889F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.66667F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // AddNewProductTypeButton
            // 
            this.AddNewProductTypeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddNewProductTypeButton.Location = new System.Drawing.Point(3, 3);
            this.AddNewProductTypeButton.Name = "AddNewProductTypeButton";
            this.AddNewProductTypeButton.Size = new System.Drawing.Size(194, 80);
            this.AddNewProductTypeButton.TabIndex = 0;
            this.AddNewProductTypeButton.Text = "AddNewProductTypeButton";
            this.AddNewProductTypeButton.UseVisualStyleBackColor = true;
            this.AddNewProductTypeButton.Click += new System.EventHandler(this.AddNewProductTypeButton_Click);
            // 
            // ProductTypeTextBox
            // 
            this.ProductTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductTypeTextBox.Location = new System.Drawing.Point(203, 3);
            this.ProductTypeTextBox.Name = "ProductTypeTextBox";
            this.ProductTypeTextBox.Size = new System.Drawing.Size(194, 20);
            this.ProductTypeTextBox.TabIndex = 1;
            // 
            // DeleteProductTypeButton
            // 
            this.DeleteProductTypeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteProductTypeButton.Location = new System.Drawing.Point(3, 89);
            this.DeleteProductTypeButton.Name = "DeleteProductTypeButton";
            this.DeleteProductTypeButton.Size = new System.Drawing.Size(194, 70);
            this.DeleteProductTypeButton.TabIndex = 2;
            this.DeleteProductTypeButton.Text = "Delete";
            this.DeleteProductTypeButton.UseVisualStyleBackColor = true;
            this.DeleteProductTypeButton.Click += new System.EventHandler(this.DeleteProductTypeButton_Click);
            // 
            // DeleteProductTypeTextBox
            // 
            this.DeleteProductTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteProductTypeTextBox.Location = new System.Drawing.Point(203, 89);
            this.DeleteProductTypeTextBox.Name = "DeleteProductTypeTextBox";
            this.DeleteProductTypeTextBox.Size = new System.Drawing.Size(194, 20);
            this.DeleteProductTypeTextBox.TabIndex = 3;
            // 
            // ProductTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "ProductTypeForm";
            this.Text = "ProductTypeForm";
            this.Load += new System.EventHandler(this.ProductTypeForm_Load);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.Button AddNewProductTypeButton;
        private System.Windows.Forms.TextBox ProductTypeTextBox;
        private System.Windows.Forms.Button DeleteProductTypeButton;
        private System.Windows.Forms.TextBox DeleteProductTypeTextBox;
    }
}