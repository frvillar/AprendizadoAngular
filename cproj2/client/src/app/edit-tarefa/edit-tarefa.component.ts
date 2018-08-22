import { Component, Injector } from '@angular/core';
import { EditTarefaGenerated } from './edit-tarefa-generated.component';

@Component({
  selector: 'edit-tarefa',
  templateUrl: './edit-tarefa.component.html'
})
export class EditTarefaComponent extends EditTarefaGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
