import { Component, Injector } from '@angular/core';
import { AddPapeiGenerated } from './add-papei-generated.component';

@Component({
  selector: 'add-papei',
  templateUrl: './add-papei.component.html'
})
export class AddPapeiComponent extends AddPapeiGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
