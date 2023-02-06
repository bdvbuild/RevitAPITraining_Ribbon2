using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Media.Imaging;

namespace RevitAPITraining_Ribbon2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Создание вкладки
            string tabName = "MyRibbon";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Doc\RevitApi\";

            //Создание панели
            var panel = application.CreateRibbonPanel(tabName, "Мои приложения");

            //Создание кнопки
            var button1 = new PushButtonData("Приложение1", "Информация", Path.Combine(utilsFolderPath, "RevitAPITraining_Button.dll"), "RevitAPITraining_Button.Main");
            var button2 = new PushButtonData("Приложение2", "Смена типа стен", Path.Combine(utilsFolderPath, "RevitAPITraining_WallTypeChanger.dll"), "RevitAPITraining_WallTypeChanger.Main");

            //Добавление иконки
            Uri uriImage1 = new Uri(@"C:\Doc\RevitApi\Images\gear.png", UriKind.Absolute);
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            button1.LargeImage = largeImage1;

            Uri uriImage2 = new Uri(@"C:\Doc\RevitApi\Images\wall.png", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;

            //Добавление кнопки на панель
            panel.AddItem(button1);
            panel.AddItem(button2);

            return Result.Succeeded;
        }
    }
}
