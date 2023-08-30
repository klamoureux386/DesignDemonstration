import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArchitectureDirectoryComponent } from './architecture-directory.component';

describe('ArchitectureDirectoryComponent', () => {
  let component: ArchitectureDirectoryComponent;
  let fixture: ComponentFixture<ArchitectureDirectoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArchitectureDirectoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArchitectureDirectoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
