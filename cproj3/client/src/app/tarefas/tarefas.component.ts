import { Component, Injector } from '@angular/core';
import { TarefasGenerated } from './tarefas-generated.component';

@Component({
  selector: 'tarefas',
  templateUrl: './tarefas.component.html'
})
export class TarefasComponent extends TarefasGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
