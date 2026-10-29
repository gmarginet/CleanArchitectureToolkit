# DefaultDocumentation writes link titles in single quotes with escaped punctuation, like 'Cat\.Commands'.
# - kramdown keeps those backslashes in the tooltip, while GitHub's markdown preview removes them.
# - jekyll-relative-links 0.7.0 only understands titles in double quotes, so these links keep pointing at .md files.
# Rewrite the titles as soon as a page is read, so the generators and kramdown see 'Cat.Commands' as "Cat.Commands".
module CatLinkTitles
  LINK_TITLE_REGEX = %r{(\]\([^)\s]+\s+)'((?:\\.|[^'\\])*)'}.freeze
  ESCAPED_PUNCTUATION_REGEX = %r{\\([!"\#$%&'()*+,\-./:;<=>?@\[\]^_`{|}~\\])}.freeze

  def self.rewrite(content)
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

  page.content = CatLinkTitles.rewrite(page.content)
end
