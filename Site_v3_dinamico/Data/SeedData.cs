using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Site_v3_dinamico.Models;
using Microsoft.AspNetCore.Identity;


namespace Site_v3_dinamico.Data
{
    public class SeedData
    {
        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "pgameiro@upskill.pt";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "Secret123$";

        private const string ROLE_ADMIN = "Administradora";

        internal static void PreencheDadosSite(SiteDinamicoBdContext bd)
        {
            InsereFormacao(bd);
            InsereFormacaoComp(bd);
            InsereExpProfissional(bd);
            InsereServicos(bd);
        }

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

        public static void InsereFormacaoComp(SiteDinamicoBdContext bd)
        {
            // Insere exemplos de formações principais(bd);

            if (bd.FormacaoComp.Any()) return;

            bd.FormacaoComp.AddRange(new FormacaoComp[] {
                new FormacaoComp
                {

                    nomeInstituicaoComp = "Instituto CRIAP",
                    dataIniciodataFimComp = "2020",
                    nomeCursoComp = "Curso de Técnico de Apoio à Vítima"

                },

                new FormacaoComp
                {

                    nomeInstituicaoComp = "Ordem dos Psicológos Portugueses",
                    dataIniciodataFimComp = "2020",
                    nomeCursoComp = "Intervenção Psicológica em Situações de Catástrofe"

                },

                new FormacaoComp
                {

                    nomeInstituicaoComp = "Mindform",
                    dataIniciodataFimComp = "2020",
                    nomeCursoComp = "Formação Pedagógica Inicial de Formadores (CCP)"

                },

                new FormacaoComp
                {

                    nomeInstituicaoComp = "Instituto CRIAP",
                    dataIniciodataFimComp = "2019",
                    nomeCursoComp = "Especialização Avançada em Terapias Cognitivo-Comportamentais para Adultos"

                },
            });

            bd.SaveChanges();
        }

        public static void InsereExpProfissional(SiteDinamicoBdContext bd)
        {
            // Insere exemplos de formações principais(bd);

            if (bd.Exp_Profissional.Any()) return;

            bd.Exp_Profissional.AddRange(new Exp_Profissional[] 
            {
                new Exp_Profissional
                {
                   nomeEmpresa = "Upskill",
                   dataInicio = 2020,
                   dataFim = 2021,
                   funcao = "Trainee",
                   descricaoFuncao = "Programa de requalificação profissional na área das novas tecnologias"+
                   "Estágio na multinacional Altran"
                },

                     new Exp_Profissional
                {
                   nomeEmpresa = "VillaRamadas",
                   dataInicio = 2017,
                   dataFim = 2020,
                   funcao = "Psicóloga clínica e da saúde",
                   descricaoFuncao = "Acompanhamento psicoterapêutico individual de jovens e adultos, de abordagem cognitivo-comportamental, em português e inglês"+
                                    "Dinamização e mediação de sessões terapêuticas de grupo (e.g.: psicoeducação, mindfulness, prevenção da recaída, terapia ocupacional)"+
                                    "Integração de equipa multidisciplinar em parceria com multinacional holandesa"+
                                    "Elaboração de planos de tratamento individuais com estabelecimento de objetivos terapêuticos"+
                                    "Aplicação de instrumentos de avaliação psicológica e elaboração de relatórios"+
                                    "Coordenação de unidade terapêutica e gestão da respetiva equipa"+
                                    "Colaboração no desenvolvimento de modelo terapêutico adaptado e de materiais psicoeducativos"+
                                    "Desempenho de tarefas administrativas e logísticas inerentes à manutenção e organização interna da unidade terapêutica"
                },

            });
            bd.SaveChanges();
        }

        public static void InsereServicos(SiteDinamicoBdContext bd)
        {
            // Insere exemplos de formações principais(bd);

            if (bd.Servicos.Any()) return;

            bd.Servicos.AddRange(new Servicos[]
            {
                new Servicos
                {
             Nome = "Design de Páginas Web",
             Descricao = "Uau"
                },

                new Servicos
                {
             Nome = "Design de Curriculum Vitae",
             Descricao = " "
                },

                new Servicos
                {
             Nome = "Desenvolvimento de aplicações",
             Descricao = "Desenvolvimento front-end e back-end de aplicações dinâmicas, intuitivas e user-friendly" 
                },

                                new Servicos
                {
             Nome = "Testes de software",
             Descricao = "Uau"
                },


            });
            bd.SaveChanges();
        }


        //internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        //{
        //    IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "joao@ipg.pt", "Secret123$");
        //    await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente ROLE_CLIENTE);

        //    IdentityUser gestor = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "maria@ipg.pt", "Secret123$");
        //    await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, gestor ROLE_GESTOR_PRODUTOS);
        //}

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADMIN);
            //await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
            //await CriaRoleSeNecessario(gestorRoles, ROLE_GESTOR_PRODUTOS);
            //await CriaRoleSeNecessario(gestorRoles, "PodeAlterarPrecoProdutos");
        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
        }

        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADMIN);
        }

        private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
        {
            if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
            {
                await gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
        }

        private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

            if (utilizador == null)
            {
                utilizador = new IdentityUser(nomeUtilizador);
                await gestorUtilizadores.CreateAsync(utilizador, password);
            }

            return utilizador;
        }


    }
}
