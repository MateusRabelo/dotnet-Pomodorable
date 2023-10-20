using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pomodorable
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Adicione um manipulador de eventos para o evento Activated
            this.Activated += MainWindow_Activated;
        }

        // Manipulador de eventos para o evento Activated
        private void MainWindow_Activated(object sender, EventArgs e)
        {
            // Coloque o código que você deseja executar quando a janela entra em foco aqui.
            // Isso será acionado quando a janela se tornar a janela ativa.
        }
    }

}
