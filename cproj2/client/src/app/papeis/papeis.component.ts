import { Component, Injector } from '@angular/core';
import { PapeisGenerated } from './papeis-generated.component';

@Component({
  selector: 'papeis',
  templateUrl: './papeis.component.html'
})
export class PapeisComponent extends PapeisGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
