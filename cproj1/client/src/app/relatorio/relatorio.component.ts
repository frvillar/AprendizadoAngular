import { Component, Injector } from '@angular/core';
import { RelatorioGenerated } from './relatorio-generated.component';

@Component({
  selector: 'relatorio',
  templateUrl: './relatorio.component.html'
})
export class RelatorioComponent extends RelatorioGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
