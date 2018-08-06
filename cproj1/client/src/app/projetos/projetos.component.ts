import { Component, Injector } from '@angular/core';
import { ProjetosGenerated } from './projetos-generated.component';

@Component({
  selector: 'projetos',
  templateUrl: './projetos.component.html'
})
export class ProjetosComponent extends ProjetosGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
