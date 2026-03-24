import { ComponentFixture, TestBed } from '@angular/core/testing';

import { reporte } from './reporte';

describe('Reporte', () => {
  let component: reporte;
  let fixture: ComponentFixture<reporte>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [reporte],
    }).compileComponents();

    fixture = TestBed.createComponent(reporte);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
