import { Component, Injector } from '@angular/core';
import { AddTarefaGenerated } from './add-tarefa-generated.component';

@Component({
  selector: 'add-tarefa',
  templateUrl: './add-tarefa.component.html'
})
export class AddTarefaComponent extends AddTarefaGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
