import { Component, Injector } from '@angular/core';
import { PessoasGenerated } from './pessoas-generated.component';

@Component({
  selector: 'pessoas',
  templateUrl: './pessoas.component.html'
})
export class PessoasComponent extends PessoasGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
