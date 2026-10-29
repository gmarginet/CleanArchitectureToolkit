# DefaultDocumentation escapes punctuation in link titles, like 'Cat\.Commands'.
# GitHub's markdown preview removes those backslashes, but kramdown keeps them in the tooltip.
# Remove them before rendering so the tooltips on the site match the preview.
module CatUnescapeLinkTitles
  LINK_TITLE_REGEX = %r{(\]\([^)\s]+\s+')((?:\\.|[^'\\])*)(')}.freeze
  ESCAPED_PUNCTUATION_REGEX = %r{\\([!"\#$%&()*+,\-./:;<=>?@\[\]^_`{|}~\\])}.freeze

  def self.unescape(content)
    content.gsub(LINK_TITLE_REGEX) do
      "#{Regexp.last_match(1)}#{Regexp.last_match(2).gsub(ESCAPED_PUNCTUATION_REGEX, '\1')}#{Regexp.last_match(3)}"
    end
  end
end

Jekyll::Hooks.register [:pages, :documents], :pre_render do |doc|
  next unless doc.extname.casecmp?(".md")

  doc.content = CatUnescapeLinkTitles.unescape(doc.content)
end
