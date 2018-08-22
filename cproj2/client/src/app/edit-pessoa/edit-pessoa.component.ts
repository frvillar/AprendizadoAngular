import { Component, Injector } from '@angular/core';
import { EditPessoaGenerated } from './edit-pessoa-generated.component';

@Component({
  selector: 'edit-pessoa',
  templateUrl: './edit-pessoa.component.html'
})
export class EditPessoaComponent extends EditPessoaGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
