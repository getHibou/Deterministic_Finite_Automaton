namespace AFD_Trabalho.ConsoleApp{
    class AFD{
        private Estado EstadoInicial {get; set;}
        private List<Estado> EstadoFinal {get; set;}
        private List<Estado> Estados {get; set;}

        public AFD(){
            EstadoFinal = new List<Estado>();
            Estados = new List<Estado>();
        }

        public AFD AdicionarEstadoInicial(Estado estadoInicial){
            EstadoInicial = estadoInicial;
            return this;
        }

        public AFD AdicionarEstadoFinal(Estado estadoFinal){
            EstadoFinal.Add(estadoFinal);
            return this;
        }

        public AFD AdicionarEstado(Estado estado){
            Estados.Add(estado);
            return this;
        }

        public AFD AdicionarEstado(List<Estado> estados){
            Estados.AddRange(estados);
            return this;
        }

        public bool Iniciar(string userInput){
            var estadoAtual = EstadoInicial;
            for(int i = 0; i < userInput.Length; i++){
                estadoAtual = estadoAtual.Valido(userInput[i].ToString());
            }
            return EstadoFinal.Contains(estadoAtual);
        }
    }

    class Estado{
        public Estado(string nome){
            Nome = nome;
            Transicoes = new Dictionary<string, Estado>();
        }

        private string Nome {get; set;}
        private Dictionary<string, Estado> Transicoes {get; set;}

        public void AdicionarTransicao(string transicao, Estado destino){
            Transicoes.Add(transicao, destino);
        }

        public Estado Valido(string transicao){
            var ehValido = Transicoes.TryGetValue(transicao, out var destino);
            if(!ehValido){
                throw new Exception("Não é válido!\n");
            }
            return destino;
        }

        public override string ToString(){
            return Nome;
        }
    }
}