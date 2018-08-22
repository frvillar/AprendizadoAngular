import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './cprojds.model';

@Injectable()
export class CprojdsService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('cprojds');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getPapeis(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, select: string | null, format: string | null) {
    return this.odata.get(`/Papeis`, { filter, top, skip, orderby, count, expand, select, format });
  }

  createPapei(papei: models.Papei | null) {
    return this.odata.post(`/Papeis`, papei);
  }

  deletePapei(papel: number | null) {
    return this.odata.delete(`/Papeis(${papel})`, item => !(item.Papel == papel));
  }

  getPapeiByPapel(papel: number | null) {
    return this.odata.get(`/Papeis(${papel})`);
  }

  updatePapei(papel: number | null, papei: models.Papei | null) {
    return this.odata.patch(`/Papeis(${papel})`, papei, item => item.Papel == papel);
  }

  getPessoas(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, select: string | null, format: string | null) {
    return this.odata.get(`/Pessoas`, { filter, top, skip, orderby, count, expand, select, format });
  }

  createPessoa(pessoa: models.Pessoa | null) {
    return this.odata.post(`/Pessoas`, pessoa);
  }

  deletePessoa(pessoa1: number | null) {
    return this.odata.delete(`/Pessoas(${pessoa1})`, item => !(item.Pessoa1 == pessoa1));
  }

  getPessoaByPessoa1(pessoa1: number | null) {
    return this.odata.get(`/Pessoas(${pessoa1})`);
  }

  updatePessoa(pessoa1: number | null, pessoa: models.Pessoa | null) {
    return this.odata.patch(`/Pessoas(${pessoa1})`, pessoa, item => item.Pessoa1 == pessoa1);
  }

  getProjetos(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, select: string | null, format: string | null) {
    return this.odata.get(`/Projetos`, { filter, top, skip, orderby, count, expand, select, format });
  }

  createProjeto(projeto: models.Projeto | null) {
    return this.odata.post(`/Projetos`, projeto);
  }

  deleteProjeto(projeto1: number | null) {
    return this.odata.delete(`/Projetos(${projeto1})`, item => !(item.Projeto1 == projeto1));
  }

  getProjetoByProjeto1(projeto1: number | null) {
    return this.odata.get(`/Projetos(${projeto1})`);
  }

  updateProjeto(projeto1: number | null, projeto: models.Projeto | null) {
    return this.odata.patch(`/Projetos(${projeto1})`, projeto, item => item.Projeto1 == projeto1);
  }

  getTarefas(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, select: string | null, format: string | null) {
    return this.odata.get(`/Tarefas`, { filter, top, skip, orderby, count, expand, select, format });
  }

  createTarefa(tarefa: models.Tarefa | null) {
    return this.odata.post(`/Tarefas`, tarefa);
  }

  deleteTarefa(tarefa1: number | null) {
    return this.odata.delete(`/Tarefas(${tarefa1})`, item => !(item.Tarefa1 == tarefa1));
  }

  getTarefaByTarefa1(tarefa1: number | null) {
    return this.odata.get(`/Tarefas(${tarefa1})`);
  }

  updateTarefa(tarefa1: number | null, tarefa: models.Tarefa | null) {
    return this.odata.patch(`/Tarefas(${tarefa1})`, tarefa, item => item.Tarefa1 == tarefa1);
  }
}
