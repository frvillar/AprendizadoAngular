export interface Papei {
  Papel: number;
  Nome: string;
  Pessoas: Array<Pessoa>;
}

export interface Pessoa {
  Pessoa1: number;
  Nome: string;
  PapelPrincipal: number;
  ativo: boolean;
  senha: string;
  Projetos: Array<Projeto>;
  Tarefas: Array<Tarefa>;
}

export interface Projeto {
  Projeto1: number;
  Descricao: string;
  Cliente: number;
  ativo: boolean;
  CentroResultado: number;
  Tarefas: Array<Tarefa>;
}

export interface Tarefa {
  Tarefa1: number;
  Data: string;
  Responsavel: number;
  Horas: number;
  Descricao: string;
  Projeto: number;
  dataDig: string;
  Manutencao: boolean;
}
