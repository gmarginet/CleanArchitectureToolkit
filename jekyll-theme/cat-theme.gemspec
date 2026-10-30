Gem::Specification.new do |spec|
  spec.name = "cat-theme"
  spec.version = "1.0.0"
  spec.authors = ["Gert Marginet"]
  spec.summary = "Jekyll theme that renders markdown like the dark mode preview of Visual Studio Code."
  spec.homepage = "https://github.com/gmarginet/CleanArchitectureToolkit"
  spec.license = "MIT"

  spec.files = Dir.glob("{_layouts,_includes,assets}/**/*") + ["README.md"]

  spec.add_runtime_dependency "jekyll", ">= 3.9", "< 5.0"
  spec.add_runtime_dependency "jekyll-seo-tag", "~> 2.8"
end
