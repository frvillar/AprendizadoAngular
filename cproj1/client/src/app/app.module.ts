import { NgModule } from '@angular/core';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AppImports, AppComponent, AppDeclarations, AppProviders } from './app.module-generated';
import { routes } from './app.routes';
import { RelatorioComponent } from './relatorio/relatorio.component'
import { RouterModule } from '@angular/router';

const customRoutes = [
    routes[0],
    {
        path: routes[1].path,
        component: routes[1].component,
        children: [
            ...routes[1].children,
            {
                path: 'relatorio/:relNome',
                component: RelatorioComponent
            }
        ]
    }
];

@NgModule({
  declarations: [
    ...AppDeclarations
  ],
  imports: [
    environment.production ? ServiceWorkerModule.register('ngsw-worker.js') : [],
      ...AppImports,
      RouterModule.forRoot(customRoutes)
  ],
  providers: [
    ...AppProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
