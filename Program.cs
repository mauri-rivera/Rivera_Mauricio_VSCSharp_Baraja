
Mazo muestraCarta = new Mazo();
Jugador jugador1 = new Jugador("Jugador A");
Jugador jugador2 = new Jugador("Jugador B");

Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("Lista de cartas ordenadas antes de empezar a barajar");
Console.WriteLine("--------------------------------------------------------");
muestraCarta.MostrarListaCartas();
Console.WriteLine("--------------------------------------------------------");

muestraCarta.listaAleatoria = muestraCarta.ReordenarBaraja(muestraCarta.listaCartas, muestraCarta.listaAleatoria);
Console.WriteLine($"La cantidad de cartas reordenadas antes del reparto {muestraCarta.listaAleatoria.Count}");
Console.WriteLine("--------------------------------------------------------");
muestraCarta.MostrarListaCartasAleatoria();

jugador1.Mano = muestraCarta.RepartirMazo(jugador1.Mano, muestraCarta.listaAleatoria, true);

Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("Se realizó el reparto de cartas al jugador");
Console.WriteLine("--------------------------------------------------------");
muestraCarta.MostrarListaCartasAleatoria();
Console.WriteLine("--------------------------------------------------------");
Console.WriteLine($"La cantidad de cartas después del reparto {muestraCarta.listaAleatoria.Count}");
Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("La lista de cartas del jugador con la carta seleccionada");
Console.WriteLine("--------------------------------------------------------");

for (int i = 0; i < jugador1.Mano.Count; i++)
{
    Console.WriteLine($"Número de carta de la lista: {i + 1}, número de la carta: {jugador1.Mano[i].Val}, {jugador1.Mano[i].Pinta}, {jugador1.Mano[i].Nombre}");
}

Console.WriteLine("--------------------------------------------------------");
Console.WriteLine($"Carta seleccionada con el rango más alto {muestraCarta.cartaSeleccionada[0].Val}, {muestraCarta.cartaSeleccionada[0].Pinta}, {muestraCarta.cartaSeleccionada[0].Nombre}");
Console.WriteLine("--------------------------------------------------------");
Console.WriteLine("La lista de cartas del jugador con la carta seleccionada devuelta al mazo");
Console.WriteLine("--------------------------------------------------------");

jugador1.Mano = muestraCarta.RepartirMazo(jugador1.Mano, muestraCarta.listaAleatoria, false);

for (int i = 0; i < jugador1.Mano.Count; i++)
{
    Console.WriteLine($"Número de carta de la lista: {i + 1}, número de la carta: {jugador1.Mano[i].Val}, {jugador1.Mano[i].Pinta}, {jugador1.Mano[i].Nombre}");
}

jugador1.DescartarCartaMazo(1, jugador1, true);
Console.WriteLine("--------------------------------------------------------");

for (int i = 0; i < jugador1.Mano.Count; i++)
{
    Console.WriteLine($"Número de carta de la lista: {i + 1}, número de la carta: {jugador1.Mano[i].Val}, {jugador1.Mano[i].Pinta}, {jugador1.Mano[i].Nombre}");
}

Console.WriteLine("--------------------------------------------------------");
jugador1.RobarCartaBaraja(jugador1, muestraCarta.listaAleatoria, true);
Console.WriteLine("--------------------------------------------------------");

for (int i = 0; i < jugador1.Mano.Count; i++)
{
    Console.WriteLine($"Número de carta de la lista: {i + 1}, número de la carta: {jugador1.Mano[i].Val}, {jugador1.Mano[i].Pinta}, {jugador1.Mano[i].Nombre}");
}

Console.WriteLine("--------------------------------------------------------");
muestraCarta.ReinicioBaraja(jugador1.Mano, muestraCarta.listaAleatoria);

Console.WriteLine($"Mazo reiniciado (cantidad): {jugador1.Mano.Count}");
Console.WriteLine($"Baraja reiniciada (si es cero, la baraja está ordenada): {muestraCarta.listaAleatoria.Count}");
Console.WriteLine("--------------------------------------------------------");

class Carta
{
    public string Nombre { get; set; }
    public string Pinta { get; set; }
    public int Val { get; set; }

    public Carta(string n, string p, int v)
    {
        Nombre = n;
        Pinta = p;
        Val = v;
    }

    public void MostrarCarta()
    {
        Console.WriteLine($"La carta representa el número {Val}, de {Pinta}, siendo {Nombre}");
    }
}

class Mazo
{
    public List<Carta> listaCartas = new List<Carta>();
    private List<string> listaPinta = new List<string>();
    public List<Carta> listaAleatoria = new List<Carta>();
    public int rangoMasAlto;
    public List<Carta> cartaSeleccionada = new List<Carta>();

    public Mazo()
    {
        listaPinta.Add("Trébol");
        listaPinta.Add("Pica");
        listaPinta.Add("Corazón");
        listaPinta.Add("Diamante");

        for (int i = 0; i < listaPinta.Count; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                if (j == 1)
                {
                    listaCartas.Add(new Carta("el As", listaPinta[i], j));
                }
                else if (j == 11)
                {
                    listaCartas.Add(new Carta("la Jota", listaPinta[i], j));
                }
                else if (j == 12)
                {
                    listaCartas.Add(new Carta("la Reina", listaPinta[i], j));
                }
                else if (j == 13)
                {
                    listaCartas.Add(new Carta("el Rey", listaPinta[i], j));
                }
                else
                {
                    listaCartas.Add(new Carta($"el {j}", listaPinta[i], j));
                }
            }
        }
    }

    public void MostrarListaCartas()
    {
        foreach (Carta carta in listaCartas)
        {
            carta.MostrarCarta();
        }
    }

    public void MostrarListaCartasAleatoria()
    {
        foreach (Carta carta in listaAleatoria)
        {
            carta.MostrarCarta();
        }
    }

    public List<Carta> RepartirMazo(List<Carta> listaMazo, List<Carta> listaBarajaAleatoria, bool estaSeleccionado)
    {
        rangoMasAlto = 0;
        int indice = 0;

        if (listaMazo.Count == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                listaMazo.Insert(i, listaBarajaAleatoria[i]);
                listaBarajaAleatoria.RemoveAt(i);
            }
        }

        for (int j = 0; j < listaMazo.Count; j++)
        {
            if (listaMazo[j].Val > rangoMasAlto)
            {
                rangoMasAlto = listaMazo[j].Val;
                indice = j;
            }
        }

        if (estaSeleccionado)
        {
            cartaSeleccionada.Add(listaMazo[indice]);
            listaMazo.RemoveAt(indice);
        }
        else
        {
            listaMazo.Add(cartaSeleccionada[0]);
            cartaSeleccionada.RemoveAt(0);
        }

        return listaMazo;
    }

    public void ReinicioBaraja(List<Carta> listaMazo, List<Carta> listaAleatoria)
    {
        listaMazo.Clear();
        listaAleatoria.Clear();
    }

    public List<Carta> ReordenarBaraja(List<Carta> listaCartaOrdenada, List<Carta> listaBarajaAleatoria)
    {
        bool coincidencia = false;
        Random indiceAleatorio = new Random();
        int j;

        while (listaBarajaAleatoria.Count < listaCartaOrdenada.Count)
        {
            j = indiceAleatorio.Next(0, listaCartaOrdenada.Count);

            if (listaBarajaAleatoria.Count > 0)
            {
                for (int i = 0; i < listaBarajaAleatoria.Count; i++)
                {
                    if (listaBarajaAleatoria[i] != listaCartaOrdenada[j])
                    {
                        if (coincidencia == false && i == (listaBarajaAleatoria.Count - 1))
                        {
                            listaBarajaAleatoria.Add(listaCartaOrdenada[j]);
                        }
                    }
                    else
                    {
                        coincidencia = true;
                    }
                }

                coincidencia = false;
            }
            else
            {
                listaBarajaAleatoria.Add(listaCartaOrdenada[j]);
            }
        }

        return listaBarajaAleatoria;
    }
}

class Jugador
{
    public string Nombre { get; set; }
    public List<Carta> Mano = new List<Carta>();
    Mazo cartasJugador = new Mazo();
    public List<Carta> cartaSeleccionadaBaraja = new List<Carta>();

    public Jugador(string n)
    {
        Nombre = n;
    }

    public void RobarCartaBaraja(Jugador jugador, List<Carta> listaBarajaAleatoria, bool cartaObtenida)
    {
        cartaSeleccionadaBaraja.Add(listaBarajaAleatoria[0]);

        Console.WriteLine($"Carta seleccionada de la baraja: {cartaSeleccionadaBaraja[0].Val}, {cartaSeleccionadaBaraja[0].Pinta}, {cartaSeleccionadaBaraja[0].Nombre}");

        if (jugador.Mano.Count < 3)
        {
            jugador.Mano.Add(cartaSeleccionadaBaraja[0]);
            listaBarajaAleatoria.Remove(cartaSeleccionadaBaraja[0]);

            if (!cartaObtenida)
            {
                listaBarajaAleatoria.Add(cartaSeleccionadaBaraja[0]);
                jugador.Mano.Remove(cartaSeleccionadaBaraja[0]);
            }
            else
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("El jugador adquiere la carta de la baraja");
            }

            cartaSeleccionadaBaraja.Clear();
        }
        else if (jugador.Mano.Count == 3)
        {
            Console.WriteLine("Sólo se obtiene la carta de la baraja si falta una carta del mazo");
        }
    }

    public void DescartarCartaMazo(int indice, Jugador jugador, bool cartaEliminadaMazo)
    {
        if (indice > 0 && indice < 4)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"La carta seleccionada del mazo: (indice) {indice}, el número de la carta {jugador.Mano[indice - 1].Val}, {jugador.Mano[indice - 1].Pinta}, {jugador.Mano[indice - 1].Nombre}");
            
            cartasJugador.cartaSeleccionada.Add(jugador.Mano[indice - 1]);
            jugador.Mano.RemoveAt(indice - 1);

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Se descarta la carta seleccionada por el jugador");
        }
        else
        {
            Console.WriteLine($"El número de la lista de carta debe ser entre 1 y 3");
        }

        if (!cartaEliminadaMazo)
        {
            jugador.Mano.Insert(indice - 1, cartasJugador.cartaSeleccionada[0]);
        }

        cartasJugador.cartaSeleccionada.Clear();
    }
}
