using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Data
{
    public class SeedData
    {
        public static void InsereFormacao(SiteDinamicoBdContext bd)
        {
            // Insere exemplos de formações principais(bd);

            if (bd.Formacao.Any()) return;

            bd.Formacao.AddRange(new Formacao[] {
                new Formacao
                {
 
                    nomeInstituicao = "Instituto Politécnico da Guarda",
                    dataIniciodataFim = "2020",
                    dataFim = new DateTime(2021,4,2),
                    nomeCurso = "Curso em Programação .NET",
                    conteudos = "- Analisar e estruturar algoritmicamente problemas computacionais e codificá-los recorrendo à linguagem de programação C# utilizando o paradigma OO; <br />" +
                                "- Entender e definir arquiteturas Cliente-Servidor, em particular em cenários Web;< br />"+
                                "-Estruturar e programar uma interface web, recorrendo a HTML e a Javascript;<br />"+
                                "- Arquiteturar aplicações servidoras em ASPNET CORE;<br />"+
                                "- Identificar e realizar as fases constituintes do Processo de Desenvolvimento de Software iterativo e incremental, em particular em sistemas Web;<br />"+
                                "- Realizar as fases da Engenharia de Requisitos;<br />"+
                                "- Modelar e inquerir informação numa base de dados relacional;"
                },
                new Formacao
                {

                    nomeInstituicao = "Faculdade de Psicologia e de Ciências da Educação da Universidade de Coimbra",
                    dataIniciodataFim = "2010 -2016",
                    dataFim = new DateTime(2021,4,2),
                    nomeCurso = "Mestrado Integrado em Psicologia",
                    conteudos = "- Mestrado em Psicologia da Educação, Desenvolvimento e Aconselhamento <br />"+
                                "- Estágio no SPO do Colégio da Rainha Santa Isabel em Coimbra<br />"+
                                "- Dissertação de mestrado 'Consciência metalinguística em crianças portuguesas com 9 anos de idade: estudo exploratório com o THAM-2'"
                      
                },

            });

            bd.SaveChanges();
        }
    }
}
