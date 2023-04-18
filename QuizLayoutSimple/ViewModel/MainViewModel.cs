using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuizLayoutSimple.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Respostas = new ObservableCollection<Resposta>() { 
                new Resposta {Descricao="São Paulo" }, 
                new Resposta { Descricao = "Porto Alegre"},
                new Resposta { Descricao = "Brasília"}
            };
        }

        [ObservableProperty]
        ObservableCollection<Resposta> respostas;

        [RelayCommand]
        void EnviarRespostas()
        {
            // Obter as respostas selecionadas
            var respostasSelecionadas = Respostas.Where(r => r.Selecionado).ToList();

            // Verificar as respostas
            bool respostaCorreta = respostasSelecionadas.Count == 1 && respostasSelecionadas[0].Descricao == "Brasília";

            // Exibir uma mensagem de resultado
            string mensagem = respostaCorreta ? "Resposta correta!" : "Resposta incorreta.";

            
        }

  
    }

    public class Resposta
    {
        public string Descricao { get; set; }
        public bool Selecionado { get; set; }
    }
}

