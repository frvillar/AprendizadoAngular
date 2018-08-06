import { Component, Injector } from '@angular/core';
import { EditPapeiGenerated } from './edit-papei-generated.component';

@Component({
  selector: 'edit-papei',
  templateUrl: './edit-papei.component.html'
})
export class EditPapeiComponent extends EditPapeiGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
