import { Component, Injector } from '@angular/core';
import { AddPessoaGenerated } from './add-pessoa-generated.component';

@Component({
  selector: 'add-pessoa',
  templateUrl: './add-pessoa.component.html'
})
export class AddPessoaComponent extends AddPessoaGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
