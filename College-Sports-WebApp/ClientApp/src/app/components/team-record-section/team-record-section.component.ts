import { Component, Input, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Competitor } from '../../models/competitor';
import { input } from '@angular/core';

@Component({
  selector: 'app-team-record-section',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './team-record-section.component.html',
  styleUrl: './team-record-section.component.css'
})
export class TeamRecordSectionComponent {

  public competitor = input.required<Competitor>();

  protected isLoading = computed(() => !(this.competitor()?.team));

  protected overallRecordText = computed(() => {
    const competitor = this.competitor();
    if (!competitor) {
      return '';
    }

    const overallRecordEntry = competitor.records?.find(record => record.name === 'overall');

    const overallRecordSummary = overallRecordEntry?.summary ?? '0-0';

    return `(${overallRecordSummary})`;
  });
}
