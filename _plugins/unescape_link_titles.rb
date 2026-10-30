# DefaultDocumentation writes link titles in single quotes with escaped punctuation, like 'Cat\.Commands'.
# - kramdown keeps those backslashes in the tooltip, while GitHub's markdown preview removes them.
# - jekyll-relative-links 0.7.0 only understands titles in double quotes, so these links keep pointing at .md files.
# Rewrite the titles as soon as a page is read, so the generators and kramdown see 'Cat.Commands' as "Cat.Commands".
#
# The stylesheet link and the logo in the header table of each page are relative to the markdown file.
# Jekyll publishes some pages one folder deeper, like "Type..ctor.md" as "Type/ctor.html", so make those paths absolute.
# Markdown links in the header are fine. jekyll-relative-links rewrites them.
module CatLinkTitles
  # A link target may contain balanced parentheses, like "Type.md#Method(System.String)".
  LINK_TITLE_REGEX = %r{(\]\((?:[^()\s]|\([^()\s]*\))+\s+)'((?:\\.|[^'\\])*)'}.freeze
  ESCAPED_PUNCTUATION_REGEX = %r{\\([!"\#$%&'()*+,\-./:;<=>?@\[\]^_`{|}~\\])}.freeze
  # The stylesheet link and the logo image, with single or double quotes, like <img src='../../resources/logo/Cat.png'>.
  RESOURCE_REGEX = %r{(<(?:link\s+href|img\s+src)=)(["'])(?:\.{1,2}/)*(resources/[^"']+)\2}.freeze

  def self.rewrite(content, baseurl)
    content = content.gsub(RESOURCE_REGEX) do
      "#{Regexp.last_match(1)}#{Regexp.last_match(2)}#{baseurl}/#{Regexp.last_match(3)}#{Regexp.last_match(2)}"
    end

    content.gsub(LINK_TITLE_REGEX) do
      # Read the groups first. The inner gsub below resets Regexp.last_match.
      original = Regexp.last_match(0)
      prefix = Regexp.last_match(1)
      title = Regexp.last_match(2).gsub(ESCAPED_PUNCTUATION_REGEX, '\1')

      title.include?('"') ? original : "#{prefix}\"#{title}\""
    end
  end
end

Jekyll::Hooks.register :pages, :post_init do |page|
  next unless page.extname.casecmp?(".md") && page.content

  page.content = CatLinkTitles.rewrite(page.content, page.site.baseurl.to_s.chomp("/"))
end
