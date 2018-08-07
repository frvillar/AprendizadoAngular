import { Component, Injector } from '@angular/core';
import { RelatorioGenerated } from './relatório-generated.component';

@Component({
  selector: 'relatório',
  templateUrl: './relatório.component.html'
})
export class RelatorioComponent extends RelatorioGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
