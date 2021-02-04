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

        private const string CLIENTE_1 = "mariaalice@upskill.pt";
        private const string CLIENTE_2 = "joaquimteles@upskill.pt";
        private const string CLIENTE_3 = "ruidebraga@upskill.pt";

        private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_ADMIN = "Administradora";

        internal static void PreencheDadosSite(SiteDinamicoBdContext bd)
        {
            InsereFormacao(bd);
            InsereFormacaoComp(bd);
            InsereExpProfissional(bd);
            InsereServicos(bd);
            InsereClientesFicticios(bd);
            InsereEncomendas(bd);
            InsereSobreMim(bd);
            InsereCompetenciasD(bd);
            InsereCompetenciasF(bd);
            InsereCompetenciasP(bd);
        }

        public static void InsereCompetenciasD(SiteDinamicoBdContext bd)
        {
            if (bd.CompetenciasD.Any()) return;

            bd.CompetenciasD.AddRange(new CompetenciasD[]
            {
                 new CompetenciasD
                 {
                     nomeComp = "HTML/CSS",
                     nivelComp = 3

                 },


                  new CompetenciasD
                 {
                     nomeComp = "C#",
                     nivelComp = 3

                 },

                  new CompetenciasD
                 {
                     nomeComp = "Boostrap",
                     nivelComp = 3

                 },

                   new CompetenciasD
                 {
                     nomeComp = "Asp Net Core",
                     nivelComp = 3

                 },

         
            });


            bd.SaveChanges();
        }

        public static void InsereCompetenciasF(SiteDinamicoBdContext bd)
        {
            if (bd.CompetenciasF.Any()) return;

            bd.CompetenciasF.AddRange(new CompetenciasF[]
            {
                 new CompetenciasF
                 {
                     nomeComp = "Photoshop",
                     nivelComp = 70

                 },


                  new CompetenciasF
                 {
                     nomeComp = "Adobe Premiere",
                     nivelComp = 40

                 },

                  new CompetenciasF
                 {
                     nomeComp = "Visual Studio",
                     nivelComp = 70

                 },

                   new CompetenciasF
                 {
                     nomeComp = "Office",
                     nivelComp = 90

                 },
            });


            bd.SaveChanges();
        }

        public static void InsereCompetenciasP(SiteDinamicoBdContext bd)
        {
            if (bd.CompetenciasP.Any()) return;

            bd.CompetenciasP.AddRange(new CompetenciasP[]
            {
                 new CompetenciasP
                 {
                     nomeComp = "Comunicação",
                     descricaoComp = "Comunicação clara e empática, adaptada ao contexto e ao tipo de público-alvo, em português e em inglês"

                 },


                  new CompetenciasP
                 {
                     nomeComp = "Trabalho em equipa",
                     descricaoComp = "Experiência em integração de equipas multidisciplinares com profissionais de diferentes nacionalidades"

                 },

                  new CompetenciasP
                 {
                     nomeComp = "Resolução de problemas",
                     descricaoComp = "Facilidade na adaptação à mudança e na criação de soluções em situações limite"

                 },

                   new CompetenciasP
                 {
                     nomeComp = "Resiliência",
                     descricaoComp = "Capacidade de gestão emocional em ambientes de trabalho exigentes com elevados padrões de qualidade"

                 },

            });


            bd.SaveChanges();
        }

        public static void InsereSobreMim(SiteDinamicoBdContext bd)
        {
            if (bd.SobreMim.Any()) return;

            bd.SobreMim.AddRange(new SobreMim[]
            {
                 new SobreMim
                 {
                     descricao = "Psicóloga em processo de requalificação profissional para Web Developer, com conhecimentos de C#, HTML, CSS e Javascript.",

                 }
            });
            bd.SaveChanges();
        }

            public static void InsereEncomendas(SiteDinamicoBdContext bd)
        {
            if (bd.Encomenda.Any()) return;

            Servicos designPaginasWeb = bd.Servicos.FirstOrDefault(c => c.Nome == "Design de Páginas Web");
            Servicos designCV = bd.Servicos.FirstOrDefault(c => c.Nome == "Design de Curriculum Vitae");
            Servicos devApp = bd.Servicos.FirstOrDefault(c => c.Nome == "Desenvolvimento de aplicações");
            Servicos testesSoftware = bd.Servicos.FirstOrDefault(c => c.Nome == "Testes de software");

            for (int i = 0; i < 10; i++)
            {
                bd.Encomenda.Add(new Encomenda
                {
                    ClienteId = 1,
                    Servicos = designPaginasWeb,
                    dataEncomenda = new DateTime(2021, 1, 12),
                    detalhes = "Procuro uma página com design intuitivo"
                });
            }

            for (int i = 0; i < 10; i++)
            {
                bd.Encomenda.Add(new Encomenda
                {
                    ClienteId = 2,
                    Servicos = designCV,
                    dataEncomenda = new DateTime(2021, 1, 13),
                    detalhes = "Quero um CV estilizado, que evidencie a minha vasta experiência profissional"
                });
            }

            for (int i = 0; i < 10; i++)
            {
                bd.Encomenda.Add(new Encomenda
                {
                    ClienteId = 3,
                    Servicos = devApp,
                    dataEncomenda = new DateTime(2021, 1, 20),
                    detalhes = "Quero uma aplicação para gerir a minha clínica."
                });
            }


            for (int i = 0; i < 10; i++)
            {
                bd.Encomenda.Add(new Encomenda
                {
                    ClienteId = 1,
                    Servicos = testesSoftware,
                    dataEncomenda = new DateTime(2021, 1, 24),
                     detalhes = "Procuro beta tester para o meu novo mod para o marketplace do Minecraft"
                });
            }
            bd.SaveChanges();
        }
        public static void InsereFormacao(SiteDinamicoBdContext bd)
        {
            // Insere exemplos de formações principais(bd);

            if (bd.Formacao.Any()) return;

            bd.Formacao.AddRange(new Formacao[] {
                new Formacao
                {
 
                    nomeInstituicao = "Instituto Politécnico da Guarda",
                    dataInicio = new DateTime(2020,10,5),
                    dataFim = new DateTime(2021,4,2),
                    nomeCurso = "Curso em Programação .NET",
                    conteudos = "- Analisar e estruturar algoritmicamente problemas computacionais e codificá-los recorrendo à linguagem de programação C# utilizando o paradigma OO; \n" +
                                "- Entender e definir arquiteturas Cliente-Servidor, em particular em cenários Web; \n "+
                                "-Estruturar e programar uma interface web, recorrendo a HTML e a Javascript; \n "+
                                "- Arquiteturar aplicações servidoras em ASPNET CORE; \n"+
                                "- Identificar e realizar as fases constituintes do Processo de Desenvolvimento de Software iterativo e incremental, em particular em sistemas Web; \n"+
                                "- Realizar as fases da Engenharia de Requisitos; \n "+
                                "- Modelar e inquerir informação numa base de dados relacional;"
                },
                new Formacao
                {

                    nomeInstituicao = "Faculdade de Psicologia e de Ciências da Educação da Universidade de Coimbra",
                    dataInicio = new DateTime(2010,9,10),
                    dataFim = new DateTime(2016,10,30),
                    nomeCurso = "Mestrado Integrado em Psicologia",
                    conteudos = "- Mestrado em Psicologia da Educação, Desenvolvimento e Aconselhamento \n"+
                                "- Estágio no SPO do Colégio da Rainha Santa Isabel em Coimbra \n"+
                                "- Dissertação de mestrado 'Consciência metalinguística em crianças portuguesas com 9 anos de idade: estudo exploratório com o THAM-2"
                      
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
                    dataIniciodataFimComp = new DateTime(2020,5,10),
                    nomeCursoComp = "Curso de Técnico de Apoio à Vítima"

                },

                new FormacaoComp
                {

                    nomeInstituicaoComp = "Ordem dos Psicológos Portugueses",
                    dataIniciodataFimComp = new DateTime(2020,5,20),
                    nomeCursoComp = "Intervenção Psicológica em Situações de Catástrofe"

                },

                new FormacaoComp
                {

                    nomeInstituicaoComp = "Mindform",
                    dataIniciodataFimComp = new DateTime(2019,12,30),
                    nomeCursoComp = "Formação Pedagógica Inicial de Formadores (CCP)"

                },

                new FormacaoComp
                {

                    nomeInstituicaoComp = "Instituto CRIAP",
                    dataIniciodataFimComp = new DateTime(2019,10,10),
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
                   dataInicio = new DateTime(2020,10,5),
                   dataFim = DateTime.Now,
                   funcao = "Trainee",
                   descricaoFuncao = "Programa de requalificação profissional na área das novas tecnologias \n"+
                   "Estágio na multinacional Altran"
                },

                     new Exp_Profissional
                {
                   nomeEmpresa = "VillaRamadas",
                   dataInicio = new DateTime(2017,4,1),
                   dataFim = new DateTime(2019,10,30),
                   funcao = "Psicóloga clínica e da saúde",
                   descricaoFuncao = "Acompanhamento psicoterapêutico individual de jovens e adultos, de abordagem cognitivo-comportamental, em português e inglês \n "+
                                    "Dinamização e mediação de sessões terapêuticas de grupo (e.g.: psicoeducação, mindfulness, prevenção da recaída, terapia ocupacional) \n"+
                                    "Integração de equipa multidisciplinar em parceria com multinacional holandesa \n "+
                                    "Elaboração de planos de tratamento individuais com estabelecimento de objetivos terapêuticos \n "+
                                    "Aplicação de instrumentos de avaliação psicológica e elaboração de relatórios \n"+
                                    "Coordenação de unidade terapêutica e gestão da respetiva equipa \n"+
                                    "Colaboração no desenvolvimento de modelo terapêutico adaptado e de materiais psicoeducativos \n"+
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
             Descricao = "Promova a sua imagem e/ou os seus produtos com um website distinto e atrativo."
                },

                new Servicos
                {
             Nome = "Design de Curriculum Vitae",
             Descricao = "Destaque as suas competências e aumente a sua empregabilidade com um CV único e personalizado."
                },

                new Servicos
                {
             Nome = "Desenvolvimento de aplicações",
             Descricao = "Desenvolvimento front-end e back-end de aplicações dinâmicas, intuitivas e user-friendly" 
                },

                new Servicos
                {
             Nome = "Testes de software",
             Descricao = "Análise minuciosa de falhas/bugs e respetiva correção para asseugrar um produto final de qualidade para o cliente,"
                },


            });
            bd.SaveChanges();
        }

        private static void InsereClientesFicticios(SiteDinamicoBdContext bd)
        {
            if (!bd.Cliente.Any(c => c.Email == CLIENTE_1))
            {
                Cliente c = new Cliente
                {
                    Nome = "Maria Alice",
                    Email = CLIENTE_1,
                    Telemóvel = "910000000"
                };

                bd.Cliente.Add(c);
                bd.SaveChanges();
            }

            if (!bd.Cliente.Any(c => c.Email == CLIENTE_2))
            {
                Cliente c = new Cliente
                {
                    Nome = "Joaquim Teles",
                    Email = CLIENTE_2,
                    Telemóvel = "910000000"
                };

                bd.Cliente.Add(c);
                bd.SaveChanges();
            }

            if (!bd.Cliente.Any(c => c.Email == CLIENTE_3))
            {
                Cliente c = new Cliente
                {
                    Nome = "Rui de Braga",
                    Email = CLIENTE_3,
                    Telemóvel = "910000000"
                };

                bd.Cliente.Add(c);
                bd.SaveChanges();
            }
        }
        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, CLIENTE_1, "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

           cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, CLIENTE_2, "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

           cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, CLIENTE_3, "Secret123$");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

            //    IdentityUser gestor = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "maria@ipg.pt", "Secret123$");
            //    await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, gestor ROLE_GESTOR_PRODUTOS);
        }

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADMIN);
            await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
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
