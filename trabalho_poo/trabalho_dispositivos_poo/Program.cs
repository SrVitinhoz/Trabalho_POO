using trabalho_dispositivos_poo.DAO;
using trabalho_dispositivos_poo.Models;

try
{
    Conexao.Conectar();
    bool continuar = true;

    while (continuar)
    {
        Console.Clear(); // Limpa a tela antes de mostrar o menu
        Console.WriteLine("Digite 1 para Insert:" +
        "\nDigite 2 para Listar" +
        "\nDigite 3 para Deletar" +
        "\nDigite 4 para Update" +
        "\nDigite 0 para Sair");

        int a = Convert.ToInt32(Console.ReadLine());
        DispositivoDAO disdao = new DispositivoDAO();

        switch (a)
        {
            case 1:
                // registrando o Dispositivo
                Dispositivos dis = new Dispositivos();
                Console.WriteLine("Aliquota do Dispositivo: ");
                dis.aliquota = float.Parse(Console.ReadLine());
                Console.WriteLine("Descrição do Dispositivo: ");
                dis.descricao = Console.ReadLine();
                Console.WriteLine("Status do Dispositivo: ");
                dis.status_dispositivo = Console.ReadLine();

                Console.WriteLine("Dispositivo cadastrado com sucesso!!!!");
                break;

            case 2:
                disdao.list();
                break;

            case 3:
                // coletando dados
                Dispositivos ID_delet = new Dispositivos();
                Console.WriteLine("ID a ser Deletado: ");
                ID_delet.Id = Convert.ToInt32(Console.ReadLine());

                // Confirmação antes de deletar
                Console.WriteLine($"Tem certeza que deseja deletar o dispositivo com ID {ID_delet.Id}? (s/n)");
                string confirmacao = Console.ReadLine().ToLower();

                if (confirmacao == "s")
                {
                    disdao.Delete(ID_delet);
                    Console.WriteLine("Dispositivo deletado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Operação de exclusão cancelada.");
                }
                break;

            case 4:
                // atualizando os dados 
                Dispositivos Up = new Dispositivos();
                Console.WriteLine("ID a ser Atualizado: ");
                Up.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Aliquota a ser Atualizada: ");
                Up.aliquota = float.Parse(Console.ReadLine());
                Console.WriteLine("Descrição a ser Atualizada: ");
                Up.descricao = Console.ReadLine();
                Console.WriteLine("Status a ser Atualizado: ");
                Up.status_dispositivo = Console.ReadLine();
                disdao.Update(Up);
                Console.WriteLine("Dispositivo Atualizado!!!!");
                break;

            case 0:
                continuar = false;
                Console.WriteLine("FIM!!!");
                break;

            default:
                Console.WriteLine("Opção inválida, tente novamente.");
                break;
        }

        if (continuar)
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(); // Espera o usuário pressionar uma tecla
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("Erro: " + ex.Message);
}
