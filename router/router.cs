using Proyecto23BMBoutique2.Vistas;
using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto23BMBoutique2.router
{
    public class Router
    {
        public static Usuario? usuario = null;
        Route route1 = new Route("/prueba", "Ruta de Prueba" , typeof(Prueba));
        Route route2 = new Route("/otra", "Ruta de Otra Ventana" , typeof(MainWindow));
        //Route[] routes = new Route[]{ route1, route2 };
        //List<Route<dynamic>> routes = new List<Route<dynamic>> { route1, route2 };
        public static List<Window> openWindows = new List<Window>();

        public static List<Route> routes = new List<Route>
        {
            new Route("/", "/", typeof(MainWindow)),
            new Route("/prueba", "Ruta de Prueba", typeof(Prueba)),
        };
        public static void FirstTime()
        {
            
            Window ventana = (Window)Activator.CreateInstance(routes[0].WindowType)!;

            //if (routes.Where( r => r.WindowType == typeof(ventana))) return;

            ventana.Show();

            openWindows.Add(ventana);

        }

        public static void Navigate(string ruta)
        {
            //if (usuario == null) return;

            // Acceso a los datos de ejemplo y mostrar las ventanas
            
            Route? route = routes.Where(route => route.Path == ruta).FirstOrDefault();

            // Acceso a los datos de ejemplo y mostrar las ventanas
            //foreach (Route x in routes)
            //{
            //    ShowWindow(x);
            //}
            ShowWindow(route);

            // Cerrar todas las ventanas secundarias abiertas
            foreach (var window in openWindows)
            {
                
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }

            //Debugger.Break();

            if (route == null) return;


        }

        public static void ShowWindow(Route route)
        {
            if (route.WindowType.IsSubclassOf(typeof(Window)))
            {
                Window ventana = (Window)Activator.CreateInstance(route.WindowType);

                Application.Current.MainWindow = ventana;

                ventana.Show();
               
                openWindows.Add(ventana);
            }
            else
            {
                Console.WriteLine("Tipo de ventana no válido.");
            }
        }
    }
}
