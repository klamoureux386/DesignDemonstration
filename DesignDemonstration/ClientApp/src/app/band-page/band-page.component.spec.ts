import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BandPageComponent } from './band-page.component';

describe('BandPageComponent', () => {
  let component: BandPageComponent;
  let fixture: ComponentFixture<BandPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BandPageComponent]
    });
    fixture = TestBed.createComponent(BandPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
