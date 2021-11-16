using Microsoft.AspNetCore.Http;
using SpMedicalGroup.Context;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        spMedicalContext ctx = new spMedicalContext();
        
        
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="IdUsuario">ID do usuário que será atualizado</param>
        /// <param name="UsuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int IdUsuario, Usuario UsuarioAtualizado)
        {
            // Busca um usuário através do id
            Usuario UsuarioBuscado = ctx.Usuarios.Find(IdUsuario);

            // Verifica se o nome do usuário foi informado
            if (UsuarioAtualizado.Nome != null)
            {
                // Atribui os novos valores ao campos existentes
                UsuarioBuscado.Nome = UsuarioAtualizado.Nome;
            }

            // Verifica se o e-mail do usuário foi informado
            if (UsuarioAtualizado.Email != null)
            {
                // Atribui os novos valores ao campos existentes
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
            }

            // Verifica se a senha do usuário foi informado
            if (UsuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores ao campos existentes
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
            }

            // Atualiza o tipo de usuário que foi buscado
            ctx.Usuarios.Update(UsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }


        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="IdUsuario">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        public Usuario BuscarPorId(int IdUsuario)
        {
           
             // Retorna o primeiro usuário encontrado para o ID informado, sem exibir sua senha
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .FirstOrDefault(u => u.IdUsuario == IdUsuario);
        }


        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="NovoUsuario">Objeto NovoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario NovoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Usuarios.Add(NovoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int IdUsuario)
        {
            string nome_novo = IdUsuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            //analisa se o arquivo existe.
            if (File.Exists(caminho))
            {
                //recupera o array de bytes.
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
                //converte em base 64.
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
        }


        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="IdUsuario">ID do usuário que será deletado</param>
        public void Deletar(int IdUsuario)
        {
            // Remove o tipo de usuário que foi buscado
            ctx.Usuarios.Remove(BuscarPorId(IdUsuario));

            // Salva as alterações
            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários, exceto as senhas
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .ToList();
        }
        
        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }

        public void SalvarPerfilDir(IFormFile foto, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        /*
        public void SalvarPerfilDir(IFormFile foto, int IdUsuario)
        {
            //instancia do objeto ImagemUsuario para gravar o arquivo no BD.
            ImagemUsuario imagemUsuario = new ImagemUsuario();

            using (var ms = new MemoryStream())
            {
                //copia a imagem enviada para a memoria.
                foto.CopyTo(ms);
                //ToArray = são os bytes da imagem.
                imagemUsuario.Binario = ms.ToArray();
                //nome do arquivo
                imagemUsuario.NomeArquivo = foto.FileName;
                //extensão do arquivo
                imagemUsuario.MimeType = foto.FileName.Split('.').Last();
                //id_usuario
                imagemUsuario.IdUsuario = IdUsuario;
            }

            //ANALISAR SE O USUARIO JA POSSUI FOTO DE PERFIL
            ImagemUsuario fotoexistente = new ImagemUsuario();
            fotoexistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == IdUsuario);

            if (fotoexistente != null)
            {
                fotoexistente.Binario = imagemUsuario.Binario;
                fotoexistente.NomeArquivo = imagemUsuario.NomeArquivo;
                fotoexistente.MimeType = imagemUsuario.MimeType;
                fotoexistente.IdUsuario = IdUsuario;

                //atualiza a imagem de perfil do usuario.
                ctx.ImagemUsuarios.Update(fotoexistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(imagemUsuario);
            }

            //salvar as modificações.
            ctx.SaveChanges();
        }*/
    }
}
