using AFD_Trabalho.ConsoleApp;

var q0 = new Estado("a");
var q1 = new Estado("b");
var q2 = new Estado("c");

q0.AdicionarTransicao("a", q0);
q0.AdicionarTransicao("b", q1);
q1.AdicionarTransicao("b", q2);
q2.AdicionarTransicao("c", q1);

String userEscolha = string.Empty;

Console.Write("\nBem Vindo ao Simulador!\n");

do{
    Console.Write("\nO que você deseja fazer?\n");
    Console.Write("\nAperte 1 para verificar a string?");
    Console.Write("\nAperte 2 para encerrar o programa?");
    Console.Write("\nEntre com a sua opção: \n");
    userEscolha = Console.ReadLine();
    switch(userEscolha){
        case "1":
            if(userEscolha == "1"){
                Console.Write("Entre com a String: ");
                var userInput = Console.ReadLine();
                var afd = new AFD()
                    .AdicionarEstado(q0).AdicionarEstado(q1).AdicionarEstado(q2)
                    .AdicionarEstadoInicial(q0)
                    .AdicionarEstadoFinal(q2);
                var resultado = afd.Iniciar(userInput);
                if(resultado == true){
                    Console.WriteLine($"{userInput} é aceito!\n");
                }else{
                    Console.WriteLine($"{userInput} não é aceito!\n");
                }
            }
            break;        
        case "2":
            if(userEscolha == "2"){
                Console.Write("Programa Encerrado :)\n");
                Environment.Exit(0);
            }
            break;
        default:
            Console.Write("Aconteceu algum problema, tente novamente!");
            break;
    }
}while(userEscolha == "1" || userEscolha == "2");