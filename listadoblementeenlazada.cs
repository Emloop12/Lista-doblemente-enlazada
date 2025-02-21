using System;

public class Nodo { // Clase nodo ahora con enlace doble
    public int valor;
    public Nodo siguiente;
    public Nodo anterior; // Nuevo puntero al nodo anterior

    public Nodo(int valor) {
        this.valor = valor;
        this.siguiente = null;
        this.anterior = null; // Se inicializa como null
    }
}

public class Listaenlazada {
    Nodo principio, final;
    public int largodelista;

    public Listaenlazada() {
        principio = null;
        final = null;
        largodelista = 0;
    }

    public void AgregarAlprincipio(int valor) {
        Nodo nuevonodo = new Nodo(valor);
        if (principio == null) {
            principio = nuevonodo;
            final = nuevonodo;
        } else {
            nuevonodo.siguiente = principio;
            principio.anterior = nuevonodo; // Se enlaza hacia atrás
            principio = nuevonodo;
        }
        largodelista++;
    }

    public void AgregarAlFinal(int valor) {
        Nodo nuevonodo = new Nodo(valor);
        if (final == null) {
            principio = nuevonodo;
            final = nuevonodo;
        } else {
            final.siguiente = nuevonodo;
            nuevonodo.anterior = final; // Se enlaza hacia atrás
            final = nuevonodo;
        }
        largodelista++;
    }

    public void AgregarNodoporindice(int valor, int posicion) {
        Nodo nuevonodo = new Nodo(valor);
        if (posicion > largodelista + 1 || posicion <= 0) {
            Console.WriteLine("Ingrese números válidos, el tamaño de la lista es de " + largodelista);
            return;
        } else if (posicion == 1) {
            AgregarAlprincipio(valor);
            return;
        } else if (posicion == largodelista + 1) {
            AgregarAlFinal(valor);
            return;
        } else {
            Nodo nodoactual = principio;
            for (int i = 1; i < posicion - 1; i++) {
                nodoactual = nodoactual.siguiente;
            }
            nuevonodo.siguiente = nodoactual.siguiente;
            nuevonodo.anterior = nodoactual;
            nodoactual.siguiente.anterior = nuevonodo; // Se enlaza el siguiente nodo con el nuevo
            nodoactual.siguiente = nuevonodo;
            largodelista++;
        }
    }

    public void EliminarPorIndice(int posicion) {
        if (principio == null) {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        if (posicion == 1) {
            if (principio.siguiente != null) {
                principio = principio.siguiente;
                principio.anterior = null; // Se actualiza el puntero anterior
            } else {
                principio = null;
                final = null;
            }
            largodelista--;
            return;
        }

        Nodo actual = principio;
        for (int i = 1; i < posicion; i++) {
            actual = actual.siguiente;
            if (actual == null) {
                Console.WriteLine("Posición fuera de rango.");
                return;
            }
        }

        if (actual.siguiente != null) {
            actual.siguiente.anterior = actual.anterior;
        }
        if (actual.anterior != null) {
            actual.anterior.siguiente = actual.siguiente;
        }
        if (actual == final) {
            final = actual.anterior;
        }
        largodelista--;
    }

    public void Imprimir() {
        if (principio == null) {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        Nodo nodoActual = principio;
        while (nodoActual != null) {
            Console.Write(nodoActual.valor + " ");
            nodoActual = nodoActual.siguiente;
        }
        Console.WriteLine();
    }
}

class Program {
    static void Main(string[] args) {
        bool estado;
        string sn;
        int numero, valor, posicion;
        Listaenlazada Listaenlazada = new Listaenlazada();

        do {
            Console.WriteLine("1. Añadir al inicio de la lista");
            Console.WriteLine("2. Añadir al final de la lista");
            Console.WriteLine("3. Añadir por posición");
            Console.WriteLine("4. Eliminar por posición");
            Console.WriteLine("5. Eliminar inicio");
            Console.WriteLine("6. Eliminar final");
            Console.WriteLine("7. Imprimir");
            numero = int.Parse(Console.ReadLine());

            if (numero == 1) {
                Console.WriteLine("Ingresa valor: ");
                valor = int.Parse(Console.ReadLine());
                Listaenlazada.AgregarAlprincipio(valor);
            } else if (numero == 2) {
                Console.WriteLine("Ingresa valor: ");
                valor = int.Parse(Console.ReadLine());
                Listaenlazada.AgregarAlFinal(valor);
            } else if (numero == 3) {
                Console.WriteLine("Ingresa valor: ");
                valor = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa posición: ");
                posicion = int.Parse(Console.ReadLine());
                Listaenlazada.AgregarNodoporindice(valor, posicion);
            } else if (numero == 4) {
                Console.WriteLine("Ingresa posición: ");
                posicion = int.Parse(Console.ReadLine());
                Listaenlazada.EliminarPorIndice(posicion);
            } else if (numero == 5) {
                Listaenlazada.EliminarPorIndice(1);
            } else if (numero == 6) {
                Listaenlazada.EliminarPorIndice(Listaenlazada.largodelista);
            } else if (numero == 7) {
                Listaenlazada.Imprimir();
            }

            Console.WriteLine("¿Quieres seguir con el programa? (s/n)");
            sn = Console.ReadLine();
            estado = sn != "n";

        } while (estado);
    }
}

