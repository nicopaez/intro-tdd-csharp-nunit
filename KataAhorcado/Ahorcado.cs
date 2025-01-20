using System.Text;

namespace AhorcadoKata;

public class Ahorcado
{
    private string estadoPalabra;
    private int vidasRestantes;
    private readonly string palabraSecreta;
    private bool juegoPerdido;
    private bool juegoGanado;
    private const int vidasRestantesIniciales = 7;

    public Ahorcado(string palabraSecreta)
    {
        const int tamanioMinimoDePalabra = 4;
        if (palabraSecreta.Length < tamanioMinimoDePalabra)
        {
            throw new PalabraCortaException();
        }

        var stringBuilder = new StringBuilder();
        for (int i = 0; i < palabraSecreta.Length; i++)
        {
            stringBuilder.Append('_');
        }
        this.estadoPalabra = stringBuilder.ToString();
        this.vidasRestantes = vidasRestantesIniciales;
        this.palabraSecreta = palabraSecreta;
        this.juegoPerdido = false;
        this.juegoGanado = false;

    }

    public string MostrarEstado()
    {
        return this.estadoPalabra;
    }

    public int VidasRestantes()
    {
        return this.vidasRestantes;
    }

    public void ProbarLetra(char letra)
    {
        AsegurarQueJuegoNoTermino();
        
        if (this.palabraSecreta.Contains(letra))
        {
            ActualizarEstadoPalabra(letra);
            
            if (this.estadoPalabra == this.palabraSecreta)
            {
                this.juegoGanado = true;
            }
        }
        else
        {
            this.vidasRestantes = this.vidasRestantes - 1;
            if (this.vidasRestantes == 0)
            {
                this.juegoPerdido = true;
            }
        }
    }

    private void ActualizarEstadoPalabra(char letra)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < this.palabraSecreta.Length; i++)
        {
            if (this.palabraSecreta[i] == letra)
            {
                stringBuilder.Append(letra);
            }
            else
            {
                stringBuilder.Append(this.estadoPalabra[i]);
            }
        }

        this.estadoPalabra = stringBuilder.ToString();
    }

    private void AsegurarQueJuegoNoTermino()
    {
        if (this.JuegoGanado() || this.JuegoPerdido())
        {
            throw new JuegoTerminadoException();
        }
    }

    public bool JuegoPerdido()
    {
        return this.juegoPerdido;
    }

    public bool JuegoGanado()
    {
        return this.juegoGanado;
    }
}

public class PalabraCortaException : ApplicationException
{}

public class JuegoTerminadoException : ApplicationException
{}