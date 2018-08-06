import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { PapeisComponent } from './papeis/papeis.component';
import { AddPapeiComponent } from './add-papei/add-papei.component';
import { EditPapeiComponent } from './edit-papei/edit-papei.component';
import { PessoasComponent } from './pessoas/pessoas.component';
import { AddPessoaComponent } from './add-pessoa/add-pessoa.component';
import { EditPessoaComponent } from './edit-pessoa/edit-pessoa.component';
import { ProjetosComponent } from './projetos/projetos.component';
import { AddProjetoComponent } from './add-projeto/add-projeto.component';
import { EditProjetoComponent } from './edit-projeto/edit-projeto.component';
import { TarefasComponent } from './tarefas/tarefas.component';
import { AddTarefaComponent } from './add-tarefa/add-tarefa.component';
import { EditTarefaComponent } from './edit-tarefa/edit-tarefa.component';
import { TarefasPorProjetoComponent } from './tarefas-por-projeto/tarefas-por-projeto.component';

export const routes: Routes = [
  { path: '', redirectTo: '/papeis', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'papeis',
        component: PapeisComponent
      },
      {
        path: 'add-papei',
        component: AddPapeiComponent
      },
      {
        path: 'edit-papei/:Papel',
        component: EditPapeiComponent
      },
      {
        path: 'pessoas',
        component: PessoasComponent
      },
      {
        path: 'add-pessoa',
        component: AddPessoaComponent
      },
      {
        path: 'edit-pessoa/:Pessoa1',
        component: EditPessoaComponent
      },
      {
        path: 'projetos',
        component: ProjetosComponent
      },
      {
        path: 'add-projeto',
        component: AddProjetoComponent
      },
      {
        path: 'edit-projeto/:Projeto1',
        component: EditProjetoComponent
      },
      {
        path: 'tarefas',
        component: TarefasComponent
      },
      {
        path: 'add-tarefa',
        component: AddTarefaComponent
      },
      {
        path: 'edit-tarefa/:Tarefa1',
        component: EditTarefaComponent
      },
      {
        path: 'tarefas-por-projeto',
        component: TarefasPorProjetoComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
