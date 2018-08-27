import { Component, Injector } from '@angular/core';
import { TarefasPorProjetoGenerated } from './tarefas-por-projeto-generated.component';

@Component({
  selector: 'tarefas-por-projeto',
  templateUrl: './tarefas-por-projeto.component.html'
})
export class TarefasPorProjetoComponent extends TarefasPorProjetoGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
