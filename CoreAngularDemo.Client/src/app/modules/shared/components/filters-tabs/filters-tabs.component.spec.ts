import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import {MatSelectModule} from '@angular/material/select';

import { FiltersTabsComponent } from './filters-tabs.component';

describe('FiltersTabsComponent', () => {
  let component: FiltersTabsComponent;
  let fixture: ComponentFixture<FiltersTabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltersTabsComponent ],
      imports: [MatSelectModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltersTabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
