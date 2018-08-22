import { Component, Injector } from '@angular/core';
import { RelatoriosGenerated } from './relatorios-generated.component';

@Component({
  selector: 'relatorios',
  templateUrl: './relatorios.component.html'
})
export class RelatoriosComponent extends RelatoriosGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
