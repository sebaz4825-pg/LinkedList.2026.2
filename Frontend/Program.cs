using System;
using Backend;

var list = new DoublyLinkedList<string>();
string option = string.Empty;

do
{
    Console.Clear();
    Menu();
    option = Console.ReadLine() ?? string.Empty;

    switch (option)
    {
        case "1": // Adicionar 
            Console.Write("Ingrese el valor a adicionar: ");
            var valueToAdd = Console.ReadLine();
            if (!string.IsNullOrEmpty(valueToAdd))
            {
                list.Add(valueToAdd, list.Get_tail1());
                Console.WriteLine("¡Elemento adicionado en orden ascendente!");
            }
            break;

        case "2": // Mostrar hacia adelante
            Console.WriteLine("\n--- Recorrido hacia adelante ---");
            Console.WriteLine(list);
            break;

        case "3": // Mostrar hacia atrás
            Console.WriteLine("\n--- Recorrido hacia atrás ---");
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4": // Ordenar descendentemente
            list.SortDescending();
            Console.WriteLine("\n¡Lista ordenada descendentemente con éxito!");
            Console.WriteLine(list);
            break;

        case "5": // Mostrar la(s) moda(s)
            var modes = list.GetModes();
            Console.WriteLine("\n--- Moda(s) de la lista ---");
            if (modes.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else if (modes.Count == 1)
            {
                Console.WriteLine($"La moda es: {modes[0]}");
            }
            else
            {
                Console.WriteLine($"Las modas son: {string.Join(", ", modes)}");
            }
            break;

        case "6": // Mostrar gráfico 
            var frequencies = list.GetFrequencies();
            Console.WriteLine("\n--- Gráfico de Ocurrencias ---");
            if (frequencies.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                foreach (var pair in frequencies)
                {
                    string stars = new string('*', pair.Value);
                    Console.WriteLine($"{pair.Key} {stars}");
                }
            }
            break;

        case "7": // Existe
            Console.Write("Ingrese el valor a buscar: ");
            var itemToSearch = Console.ReadLine();
            if (itemToSearch != null && list.Contains(itemToSearch))
            {
                Console.WriteLine($"Sí, el elemento '{itemToSearch}' sí existe en la lista.");
            }
            else
            {
                Console.WriteLine($"No, el elemento '{itemToSearch}' no existe en la lista.");
            }
            break;

        case "8": // Eliminar una ocurrencia
            Console.Write("Ingrese el valor a eliminar (primera ocurrencia): ");
            var itemToRemove = Console.ReadLine();
            if (itemToRemove != null && list.Remove(itemToRemove))
            {
                Console.WriteLine($"Se ha eliminado la primera ocurrencia de '{itemToRemove}'.");
            }
            else
            {
                Console.WriteLine($"No se encontró el elemento '{itemToRemove}' en la lista.");
            }
            break;

        case "9": // Eliminar todas las ocurrencias
            Console.Write("Ingrese el valor para eliminar todas sus ocurrencias: ");
            var itemToRemoveAll = Console.ReadLine();
            if (itemToRemoveAll != null)
            {
                int removedCount = list.RemoveAll(itemToRemoveAll);
                Console.WriteLine($"Se eliminaron {removedCount} ocurrencia(s) de '{itemToRemoveAll}'.");
            }
            break;

        case "0":
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }

    if (option != "0")
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

} while (option != "0");

static void Menu()
{
    Console.Clear();
    Console.WriteLine("{0,-35} {1}", "1. Adicionar.", "6. Mostrar gráfico.");
    Console.WriteLine("{0,-35} {1}", "2. Mostrar hacia adelante.", "7. Existe.");
    Console.WriteLine("{0,-35} {1}", "3. Mostrar hacia atrás.", "8. Eliminar una ocurrencia.");
    Console.WriteLine("{0,-35} {1}", "4. Ordenar descendentemente.", "9. Eliminar todas las ocurrencias.");
    Console.WriteLine("{0,-35} {1}", "5. Mostrar la(s) moda(s).", "0. Salir.");
    Console.Write("\nSeleccione una opción: ");
}