using ACLtest.Anticorrupcao;
using ACLtest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACLtest.Controllers
{
    public class CadastroPessoaController : Controller
    {

        public async Task<IActionResult> Pesquisar(string? cpfCnpjNome)
        {
            var model = await new CadastroPessoaClient().Pesquisa(cpfCnpjNome);
            return View("Index", new CadastroViewModel { Cadastro = new CadastroPessoaViewModel { }, List = model });
        }

        public async Task<IActionResult> Post(CadastroPessoaViewModel value)
        {

            var model = await new CadastroPessoaClient().Post(value);
            return View("Index", new CadastroViewModel { Cadastro = new CadastroPessoaViewModel { }, List = model });
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await new CadastroPessoaClient().Edit(id);
            return Ok(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            await new CadastroPessoaClient().Delete(id);
            var model = await new CadastroPessoaClient().Pesquisa("");
            return View("Index", new CadastroViewModel { Cadastro = new CadastroPessoaViewModel { }, List = model });
        }


    }
}
