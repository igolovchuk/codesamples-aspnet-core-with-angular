import { Component, OnInit, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { Issue } from '../../models/issue';
import { AuthenticationService } from 'src/app/modules/core/services/authentication.service';
import { MatPaginator, MatSort } from '@angular/material';
import { TranslateService, TranslateDefaultParser } from '@ngx-translate/core';
import { MatPaginatorIntlCustom } from '../../paginator-extentions/mat-paginator-intl-custom';
import { fromEvent, merge } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators';
import { IssueService } from '../../services/issue.service';
import { Priority } from 'src/app/modules/core/models/priority/priority';
import { Router } from '@angular/router';
import { IssueDataSource } from '../../data-sources/issue-data-source';
import { PropertyFilter } from '../../models/property-filter';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';
import { TokenStore } from 'src/app/modules/core/helpers/token-store';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: [
    '../tables/mat-fsp-table/mat-fsp-table.component.scss',
    './issue.component.scss',
  ]
})
export class IssueComponent implements OnInit, AfterViewInit {
  priority = [Priority.high, Priority.medium, Priority.low];
  
  selectedIssue: Issue;
  filters: PropertyFilter[];
  isRegister: boolean;
  isAnalyst: boolean;
  isEngineer: boolean;

  columnDefinitions: string[] = [
    "number",
    "state",
    "malfunctionGroup",
    "malfunctionSubgroup",
    "malfunction",
    "priority",
    "warranty",
    "vehicle",
    "assignee",
    "deadline",
    "location",
    "summary",
    "created",
    "updated"
  ];

  analystColumns: string[] = [
    "vehicle",
    "state",
    "malfunctionGroup",
    "malfunctionSubgroup",
    "malfunction",
    "location",
    "warranty",
  ];

  engineerColumns: string[] = [
    "number",
    "state",
    "malfunctionGroup",
    "malfunctionSubgroup",
    "malfunction",
    "priority",
    "warranty",
    "vehicle",
    "assignee",
    "deadline",
    "location",
    "summary",
    "created",
    "updated",
    "actions"
  ];

  registerColumns: string[] = [
    "vehicle",
    "state",
    "malfunctionGroup",
    "malfunctionSubgroup",
    "malfunction",
    "warranty",
    "summary",
    "actions"
  ];


  columnsToDisplay: string[];

  dataSource: IssueDataSource;
  
  sortedColumn: string;


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('input') input: ElementRef;
  
  private hubConnection: HubConnection;

  constructor(
    private authenticationService: AuthenticationService,
    private issueService: IssueService,
    private router: Router,
    private tokenStore: TokenStore,
    private toastr: ToastrService,
    private translate: TranslateService) {
  }

  ngOnInit() {
    this.dataSource = new IssueDataSource(this.issueService);
    this.paginator._intl = new MatPaginatorIntlCustom(this.translate, new TranslateDefaultParser());

    const role = this.authenticationService.getRole()
    if (role == "ENGINEER") {
      this.isEngineer = true;
      this.columnsToDisplay = this.engineerColumns;
    }
    else if (role == "ANALYST") {
      this.isAnalyst = true;
      this.columnsToDisplay = this.analystColumns;
    }
    else if (role == "REGISTER") {
      this.isRegister = true;
      this.columnsToDisplay = this.registerColumns;
    }

    this.refreshTable();
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    fromEvent(this.input.nativeElement, 'keyup').pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => {
        this.paginator.pageIndex = 0;
        this.refreshTable();
      })
    ).subscribe();

    merge(this.sort.sortChange, this.paginator.page).pipe(
      tap(() => this.refreshTable())
    ).subscribe();
  }

  private startConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.signalrIssueUrl, {
        accessTokenFactory: () => this.tokenStore.getToken().accessToken
      })
      .build();

    this.hubConnection.on('ReceiveIssues', _ => {
      this.refreshTable();
      this.toastr.info('У вас нові заявки!', 'Сповіщення')
    });

    this.hubConnection
      .start()
      .catch(_ =>
        this.toastr.warning('Ваш браузер ймовірно не підтримує деякий функціонал.', 'Помилка під час з\'єднання!'));
  }

  refreshTable() {
    this.dataSource.loadFilteredEntities(
      this.input.nativeElement.value,
      this.filters,
      { direction: this.sort.direction, columnDef: this.sort.active },
      this.paginator.pageIndex,
      this.paginator.pageSize,
      this.paginator
    );
  }

  setFilters(filters: PropertyFilter[] ) { 
    this.filters = filters;
  }

  selectIssue(issue: Issue) {
    this.issueService.selectedItem = issue;
    this.router.navigate(['/engineer/issues/edit']);
  }
}
