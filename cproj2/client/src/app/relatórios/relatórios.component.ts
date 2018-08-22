import { Component, Injector } from '@angular/core';
import { RelatoriosGenerated } from './relatórios-generated.component';

@Component({
  selector: 'relatórios',
  templateUrl: './relatórios.component.html'
})
export class RelatoriosComponent extends RelatoriosGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
