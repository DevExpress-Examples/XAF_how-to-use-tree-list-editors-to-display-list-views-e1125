using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace HowToUseTreeListEditor.Win {
    public partial class HowToUseTreeListEditorWindowsFormsApplication : WinApplication {
        public HowToUseTreeListEditorWindowsFormsApplication() {
            InitializeComponent();
        }

        private void HowToUseTreeListEditorWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
