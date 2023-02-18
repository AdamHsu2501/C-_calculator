namespace MyCalculator
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNegate = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonDecimalPoint = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAddition = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonSubtraction = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonMultiplication = new System.Windows.Forms.Button();
            this.buttonLeftParenthesis = new System.Windows.Forms.Button();
            this.buttonRightParenthesis = new System.Windows.Forms.Button();
            this.buttonSquareRoot = new System.Windows.Forms.Button();
            this.buttonDivision = new System.Windows.Forms.Button();
            this.percentBtn = new System.Windows.Forms.Button();
            this.buttonClearEntry = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.mcBtn = new System.Windows.Forms.Button();
            this.mrBtn = new System.Windows.Forms.Button();
            this.mAddBtn = new System.Windows.Forms.Button();
            this.mMinusBtn = new System.Windows.Forms.Button();
            this.msBtn = new System.Windows.Forms.Button();
            this.mViewBtn = new System.Windows.Forms.Button();
            this.menuBtn = new System.Windows.Forms.Button();
            this.topBtn = new System.Windows.Forms.Button();
            this.historyBtn = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelFormula = new System.Windows.Forms.Label();
            this.modeLabel = new System.Windows.Forms.Label();
            this.labelInfix = new System.Windows.Forms.Label();
            this.labelPrefix = new System.Windows.Forms.Label();
            this.labelPostfix = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNegate
            // 
            this.buttonNegate.Location = new System.Drawing.Point(12, 590);
            this.buttonNegate.Name = "buttonNegate";
            this.buttonNegate.Size = new System.Drawing.Size(75, 52);
            this.buttonNegate.TabIndex = 0;
            this.buttonNegate.Text = "±";
            this.buttonNegate.UseVisualStyleBackColor = true;
            this.buttonNegate.Click += new System.EventHandler(this.button_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(93, 590);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(75, 52);
            this.button0.TabIndex = 1;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonDecimalPoint
            // 
            this.buttonDecimalPoint.Location = new System.Drawing.Point(174, 590);
            this.buttonDecimalPoint.Name = "buttonDecimalPoint";
            this.buttonDecimalPoint.Size = new System.Drawing.Size(75, 52);
            this.buttonDecimalPoint.TabIndex = 2;
            this.buttonDecimalPoint.Text = ".";
            this.buttonDecimalPoint.UseVisualStyleBackColor = true;
            this.buttonDecimalPoint.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonEqual
            // 
            this.buttonEqual.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonEqual.Location = new System.Drawing.Point(255, 590);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(75, 52);
            this.buttonEqual.TabIndex = 3;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = false;
            this.buttonEqual.Click += new System.EventHandler(this.button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 532);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 532);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 52);
            this.button3.TabIndex = 6;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonAddition
            // 
            this.buttonAddition.Location = new System.Drawing.Point(255, 532);
            this.buttonAddition.Name = "buttonAddition";
            this.buttonAddition.Size = new System.Drawing.Size(75, 52);
            this.buttonAddition.TabIndex = 7;
            this.buttonAddition.Text = "+";
            this.buttonAddition.UseVisualStyleBackColor = true;
            this.buttonAddition.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 474);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 52);
            this.button4.TabIndex = 8;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(93, 474);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 52);
            this.button5.TabIndex = 9;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(174, 474);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 52);
            this.button6.TabIndex = 10;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonSubtraction
            // 
            this.buttonSubtraction.Location = new System.Drawing.Point(255, 474);
            this.buttonSubtraction.Name = "buttonSubtraction";
            this.buttonSubtraction.Size = new System.Drawing.Size(75, 52);
            this.buttonSubtraction.TabIndex = 11;
            this.buttonSubtraction.Text = "-";
            this.buttonSubtraction.UseVisualStyleBackColor = true;
            this.buttonSubtraction.Click += new System.EventHandler(this.button_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 416);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 52);
            this.button7.TabIndex = 12;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(93, 416);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 52);
            this.button8.TabIndex = 13;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(174, 416);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 52);
            this.button9.TabIndex = 14;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonMultiplication
            // 
            this.buttonMultiplication.Location = new System.Drawing.Point(255, 416);
            this.buttonMultiplication.Name = "buttonMultiplication";
            this.buttonMultiplication.Size = new System.Drawing.Size(75, 52);
            this.buttonMultiplication.TabIndex = 15;
            this.buttonMultiplication.Text = "*";
            this.buttonMultiplication.UseVisualStyleBackColor = true;
            this.buttonMultiplication.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonLeftParenthesis
            // 
            this.buttonLeftParenthesis.Location = new System.Drawing.Point(12, 358);
            this.buttonLeftParenthesis.Name = "buttonLeftParenthesis";
            this.buttonLeftParenthesis.Size = new System.Drawing.Size(75, 52);
            this.buttonLeftParenthesis.TabIndex = 16;
            this.buttonLeftParenthesis.Text = "(";
            this.buttonLeftParenthesis.UseVisualStyleBackColor = true;
            this.buttonLeftParenthesis.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonRightParenthesis
            // 
            this.buttonRightParenthesis.Location = new System.Drawing.Point(93, 358);
            this.buttonRightParenthesis.Name = "buttonRightParenthesis";
            this.buttonRightParenthesis.Size = new System.Drawing.Size(75, 52);
            this.buttonRightParenthesis.TabIndex = 17;
            this.buttonRightParenthesis.Text = ")";
            this.buttonRightParenthesis.UseVisualStyleBackColor = true;
            this.buttonRightParenthesis.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonSquareRoot
            // 
            this.buttonSquareRoot.Location = new System.Drawing.Point(174, 358);
            this.buttonSquareRoot.Name = "buttonSquareRoot";
            this.buttonSquareRoot.Size = new System.Drawing.Size(75, 52);
            this.buttonSquareRoot.TabIndex = 18;
            this.buttonSquareRoot.Text = "√";
            this.buttonSquareRoot.UseVisualStyleBackColor = true;
            this.buttonSquareRoot.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonDivision
            // 
            this.buttonDivision.Location = new System.Drawing.Point(255, 358);
            this.buttonDivision.Name = "buttonDivision";
            this.buttonDivision.Size = new System.Drawing.Size(75, 52);
            this.buttonDivision.TabIndex = 19;
            this.buttonDivision.Text = "/";
            this.buttonDivision.UseVisualStyleBackColor = true;
            this.buttonDivision.Click += new System.EventHandler(this.button_Click);
            // 
            // percentBtn
            // 
            this.percentBtn.Location = new System.Drawing.Point(12, 300);
            this.percentBtn.Name = "percentBtn";
            this.percentBtn.Size = new System.Drawing.Size(75, 52);
            this.percentBtn.TabIndex = 20;
            this.percentBtn.Text = "%";
            this.percentBtn.UseVisualStyleBackColor = true;
            // 
            // buttonClearEntry
            // 
            this.buttonClearEntry.Location = new System.Drawing.Point(93, 300);
            this.buttonClearEntry.Name = "buttonClearEntry";
            this.buttonClearEntry.Size = new System.Drawing.Size(75, 52);
            this.buttonClearEntry.TabIndex = 21;
            this.buttonClearEntry.Text = "CE";
            this.buttonClearEntry.UseVisualStyleBackColor = true;
            this.buttonClearEntry.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(174, 300);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 52);
            this.buttonClear.TabIndex = 22;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Location = new System.Drawing.Point(255, 300);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(75, 52);
            this.buttonBackspace.TabIndex = 23;
            this.buttonBackspace.Text = "B";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.button_Click);
            // 
            // mcBtn
            // 
            this.mcBtn.Enabled = false;
            this.mcBtn.Location = new System.Drawing.Point(12, 256);
            this.mcBtn.Name = "mcBtn";
            this.mcBtn.Size = new System.Drawing.Size(46, 38);
            this.mcBtn.TabIndex = 24;
            this.mcBtn.Text = "MC";
            this.mcBtn.UseVisualStyleBackColor = true;
            // 
            // mrBtn
            // 
            this.mrBtn.Enabled = false;
            this.mrBtn.Location = new System.Drawing.Point(64, 256);
            this.mrBtn.Name = "mrBtn";
            this.mrBtn.Size = new System.Drawing.Size(46, 38);
            this.mrBtn.TabIndex = 25;
            this.mrBtn.Text = "MR";
            this.mrBtn.UseVisualStyleBackColor = true;
            // 
            // mAddBtn
            // 
            this.mAddBtn.Location = new System.Drawing.Point(116, 256);
            this.mAddBtn.Name = "mAddBtn";
            this.mAddBtn.Size = new System.Drawing.Size(47, 38);
            this.mAddBtn.TabIndex = 26;
            this.mAddBtn.Text = "M+";
            this.mAddBtn.UseVisualStyleBackColor = true;
            // 
            // mMinusBtn
            // 
            this.mMinusBtn.Location = new System.Drawing.Point(174, 256);
            this.mMinusBtn.Name = "mMinusBtn";
            this.mMinusBtn.Size = new System.Drawing.Size(47, 38);
            this.mMinusBtn.TabIndex = 27;
            this.mMinusBtn.Text = "M-";
            this.mMinusBtn.UseVisualStyleBackColor = true;
            // 
            // msBtn
            // 
            this.msBtn.Location = new System.Drawing.Point(227, 256);
            this.msBtn.Name = "msBtn";
            this.msBtn.Size = new System.Drawing.Size(43, 38);
            this.msBtn.TabIndex = 28;
            this.msBtn.Text = "MS";
            this.msBtn.UseVisualStyleBackColor = true;
            // 
            // mViewBtn
            // 
            this.mViewBtn.Location = new System.Drawing.Point(276, 256);
            this.mViewBtn.Name = "mViewBtn";
            this.mViewBtn.Size = new System.Drawing.Size(43, 38);
            this.mViewBtn.TabIndex = 29;
            this.mViewBtn.Text = "M🢗";
            this.mViewBtn.UseVisualStyleBackColor = true;
            // 
            // menuBtn
            // 
            this.menuBtn.Location = new System.Drawing.Point(12, 12);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(46, 38);
            this.menuBtn.TabIndex = 30;
            this.menuBtn.Text = "☰";
            this.menuBtn.UseVisualStyleBackColor = true;
            // 
            // topBtn
            // 
            this.topBtn.Location = new System.Drawing.Point(128, 11);
            this.topBtn.Name = "topBtn";
            this.topBtn.Size = new System.Drawing.Size(46, 38);
            this.topBtn.TabIndex = 31;
            this.topBtn.Text = "Top";
            this.topBtn.UseVisualStyleBackColor = true;
            // 
            // historyBtn
            // 
            this.historyBtn.Location = new System.Drawing.Point(285, 12);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(46, 38);
            this.historyBtn.TabIndex = 32;
            this.historyBtn.Text = "history";
            this.historyBtn.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResult.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelResult.Location = new System.Drawing.Point(12, 101);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(319, 48);
            this.labelResult.TabIndex = 33;
            this.labelResult.Text = "0";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFormula
            // 
            this.labelFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFormula.Enabled = false;
            this.labelFormula.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelFormula.Location = new System.Drawing.Point(12, 67);
            this.labelFormula.Name = "labelFormula";
            this.labelFormula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelFormula.Size = new System.Drawing.Size(307, 19);
            this.labelFormula.TabIndex = 34;
            this.labelFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.modeLabel.Location = new System.Drawing.Point(64, 16);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(58, 24);
            this.modeLabel.TabIndex = 35;
            this.modeLabel.Text = "標準";
            // 
            // labelInfix
            // 
            this.labelInfix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfix.Enabled = false;
            this.labelInfix.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInfix.Location = new System.Drawing.Point(23, 155);
            this.labelInfix.Name = "labelInfix";
            this.labelInfix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelInfix.Size = new System.Drawing.Size(307, 19);
            this.labelInfix.TabIndex = 36;
            this.labelInfix.Text = "infix";
            this.labelInfix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPrefix
            // 
            this.labelPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrefix.Enabled = false;
            this.labelPrefix.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPrefix.Location = new System.Drawing.Point(23, 188);
            this.labelPrefix.Name = "labelPrefix";
            this.labelPrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPrefix.Size = new System.Drawing.Size(307, 19);
            this.labelPrefix.TabIndex = 37;
            this.labelPrefix.Text = "prefix";
            this.labelPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPostfix
            // 
            this.labelPostfix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPostfix.Enabled = false;
            this.labelPostfix.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPostfix.Location = new System.Drawing.Point(23, 220);
            this.labelPostfix.Name = "labelPostfix";
            this.labelPostfix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPostfix.Size = new System.Drawing.Size(307, 19);
            this.labelPostfix.TabIndex = 38;
            this.labelPostfix.Text = "postfix";
            this.labelPostfix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 656);
            this.Controls.Add(this.labelPostfix);
            this.Controls.Add(this.labelPrefix);
            this.Controls.Add(this.labelInfix);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.labelFormula);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.historyBtn);
            this.Controls.Add(this.topBtn);
            this.Controls.Add(this.menuBtn);
            this.Controls.Add(this.mViewBtn);
            this.Controls.Add(this.msBtn);
            this.Controls.Add(this.mMinusBtn);
            this.Controls.Add(this.mAddBtn);
            this.Controls.Add(this.mrBtn);
            this.Controls.Add(this.mcBtn);
            this.Controls.Add(this.buttonBackspace);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonClearEntry);
            this.Controls.Add(this.percentBtn);
            this.Controls.Add(this.buttonDivision);
            this.Controls.Add(this.buttonSquareRoot);
            this.Controls.Add(this.buttonRightParenthesis);
            this.Controls.Add(this.buttonLeftParenthesis);
            this.Controls.Add(this.buttonMultiplication);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.buttonSubtraction);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonAddition);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.buttonDecimalPoint);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.buttonNegate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNegate;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonDecimalPoint;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAddition;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonSubtraction;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button buttonMultiplication;
        private System.Windows.Forms.Button buttonLeftParenthesis;
        private System.Windows.Forms.Button buttonRightParenthesis;
        private System.Windows.Forms.Button buttonSquareRoot;
        private System.Windows.Forms.Button buttonDivision;
        private System.Windows.Forms.Button percentBtn;
        private System.Windows.Forms.Button buttonClearEntry;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.Button mcBtn;
        private System.Windows.Forms.Button mrBtn;
        private System.Windows.Forms.Button mAddBtn;
        private System.Windows.Forms.Button mMinusBtn;
        private System.Windows.Forms.Button msBtn;
        private System.Windows.Forms.Button mViewBtn;
        private System.Windows.Forms.Button menuBtn;
        private System.Windows.Forms.Button topBtn;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelFormula;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label labelInfix;
        private System.Windows.Forms.Label labelPrefix;
        private System.Windows.Forms.Label labelPostfix;
    }
}