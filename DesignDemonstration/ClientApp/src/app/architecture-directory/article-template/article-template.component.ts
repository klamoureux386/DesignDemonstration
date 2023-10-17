import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ArticleClient, ArticleDTO } from 'src/api.generated.clients';

@Component({
  selector: 'app-article-template',
  templateUrl: './article-template.component.html',
  styleUrls: ['./article-template.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [ArticleClient]
})
export class ArticleTemplateComponent implements OnInit {

  public article: ArticleDTO = new ArticleDTO();

  constructor(private articleClient: ArticleClient) {

  }

  ngOnInit() {
    this.getArticle(1);
  }

  getArticle(id: number) {
    this.articleClient.get(id).subscribe(res => {
      this.article = res
      this.insertImgElements();
    })
  }

  insertImgElements() {

    let maxImages = 20;

    for (let i = 0; i < this.article.imgSrcs.length && i < maxImages; i++) {
      this.article.text = this.article.text.replace(`<Image[${i}]>`, `<img src=\"assets/query_projection/${this.article.imgSrcs[i]}\" class=\"template-img\">`)
    }
    
  }

}
